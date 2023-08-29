using System;
using System.Text.Json;

namespace MultiTimezoneClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<String> timezones = getTimezones();

            if (timezones.Count <= 0) { return; }

            timezonesComboBox.Items.Clear();
            timezonesComboBox.Items.AddRange(timezones.ToArray());

            syncronizeTimer();

            this.WindowState = FormWindowState.Minimized;
            Hide();
            ShowInTaskbar = false;
        }

        private void syncronizeTimer()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var response = httpClient.GetStringAsync("https://worldtimeapi.org/api/timezone/Europe/Lisbon").Result;
                var timezoneInfo = JsonSerializer.Deserialize<TimezoneDTO>(response);

                var time = Convert.ToDateTime(timezoneInfo?.datetime);

                readFile();

                timer1.Stop();
                timer1.Interval = (60 - time.Second) * 1000;
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<String> getTimezones()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var response = httpClient.GetStringAsync("https://worldtimeapi.org/api/timezone/").Result;
                var timezones = JsonSerializer.Deserialize<List<String>>(response);

                return timezones ?? new List<String>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<String>();
            }

        }

        private void timezoneAddBtn_Click(object sender, EventArgs e)
        {
            if (timezonesComboBox.SelectedIndex <= 0) { return; }

            var duplicated = checkDuplicate(timezonesComboBox.SelectedItem.ToString());
            if (duplicated) { return; }

            addTimezone(timezonesComboBox.SelectedItem.ToString());
        }

        private bool checkDuplicate(string timezone)
        {
            for (int i = 0; i < timezonesList.Rows.Count; i++)
            {
                if (timezonesList.Rows[i].Cells[0].Value.ToString().Equals(timezone)) { return true; }
            }

            return false;
        }

        private void addTimezone(string timezone)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var response = httpClient.GetStringAsync($"https://worldtimeapi.org/api/timezone/{timezone}").Result;
                var timezoneInfo = JsonSerializer.Deserialize<TimezoneDTO>(response);

                var date = DateTimeOffset.Parse(timezoneInfo.datetime, null).ToString("dd/MM/yyyy");
                var time = DateTimeOffset.Parse(timezoneInfo.datetime, null).ToString("HH:mm");

                timezonesList.Rows.Add(timezoneInfo?.timezone, timezoneInfo?.datetime, time, date);

                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Text = $"{timezoneInfo.timezone} - {time} - {date}";
                toolStripMenuItem.Enabled = false;

                if (contextMenuStrip1.Items.Count == 1) { contextMenuStrip1.Items.Insert(0, new ToolStripSeparator()); }

                contextMenuStrip1.Items.Insert(contextMenuStrip1.Items.Count - 2, toolStripMenuItem);
                saveFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval != 60000)
            {
                timer1.Stop();
                timer1.Interval = 60000;
                timer1.Start();
            }

            for (int i = 0; i < timezonesList.Rows.Count; i++)
            {
                var datetime = DateTimeOffset.Parse(timezonesList.Rows[i].Cells["ListDateTime"].Value.ToString(), null);
                datetime = datetime.AddMinutes(1);
                timezonesList.Rows[i].Cells["ListDateTime"].Value = datetime.ToString();
                timezonesList.Rows[i].Cells["ListDate"].Value = datetime.ToString("dd/MM/yyyy");
                timezonesList.Rows[i].Cells["ListTime"].Value = datetime.ToString("HH:mm");

                contextMenuStrip1.Items[i].Text = $"{timezonesList.Rows[i].Cells["ListTimezone"].Value} - {datetime.ToString("HH:mm")} - {datetime.ToString("dd/MM/yyyy")}";
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            ShowInTaskbar = true;
        }

        private void timezonesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (timezonesList.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    timezonesList.Rows.RemoveAt(e.RowIndex);
                    contextMenuStrip1.Items.RemoveAt(e.RowIndex);
                    saveFile();

                    if (contextMenuStrip1.Items.Count == 2) { contextMenuStrip1.Items.RemoveAt(0); }
                }
            }
            catch (Exception)
            {
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Enabled = false;
            contextMenuStrip1.Close();
            contextMenuStrip1.Dispose();
            Close();
        }

        private void saveFile()
        {
            try
            {
                var timezonesPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/MultiTimezoneClock/";
                var fileName = "timezones.txt";
                var stream = "";

                if (!Directory.Exists(timezonesPath)) { Directory.CreateDirectory(timezonesPath); }

                for (int i = 0; i < timezonesList.Rows.Count; i++)
                {
                    stream += timezonesList.Rows[i].Cells["ListTimezone"].Value;
                    if (i + 1 < timezonesList.Rows.Count) { stream += "\n"; }
                }

                File.WriteAllText($"{timezonesPath}{fileName}", stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readFile()
        {
            try
            {
                var timezonesPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/MultiTimezoneClock/";
                var fileName = "timezones.txt";
                var stream = File.ReadAllLines($"{timezonesPath}{fileName}");

                foreach (var line in stream)
                {
                    addTimezone(line);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}