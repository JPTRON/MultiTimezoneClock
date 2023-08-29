namespace MultiTimezoneClock
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timezonesComboBox = new ComboBox();
            timezonesList = new DataGridView();
            ListTimezone = new DataGridViewTextBoxColumn();
            ListDateTime = new DataGridViewTextBoxColumn();
            ListTime = new DataGridViewTextBoxColumn();
            ListDate = new DataGridViewTextBoxColumn();
            ListDelete = new DataGridViewButtonColumn();
            timezoneAddBtn = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            exitToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)timezonesList).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // timezonesComboBox
            // 
            timezonesComboBox.FormattingEnabled = true;
            timezonesComboBox.Location = new Point(12, 12);
            timezonesComboBox.Name = "timezonesComboBox";
            timezonesComboBox.Size = new Size(325, 23);
            timezonesComboBox.TabIndex = 0;
            // 
            // timezonesList
            // 
            timezonesList.AllowUserToAddRows = false;
            timezonesList.AllowUserToDeleteRows = false;
            timezonesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            timezonesList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            timezonesList.Columns.AddRange(new DataGridViewColumn[] { ListTimezone, ListDateTime, ListTime, ListDate, ListDelete });
            timezonesList.Location = new Point(12, 41);
            timezonesList.Name = "timezonesList";
            timezonesList.ReadOnly = true;
            timezonesList.RowHeadersVisible = false;
            timezonesList.RowTemplate.Height = 25;
            timezonesList.Size = new Size(443, 150);
            timezonesList.TabIndex = 1;
            timezonesList.CellClick += timezonesList_CellClick;
            // 
            // ListTimezone
            // 
            ListTimezone.HeaderText = "Timezone";
            ListTimezone.Name = "ListTimezone";
            ListTimezone.ReadOnly = true;
            // 
            // ListDateTime
            // 
            ListDateTime.HeaderText = "DateTime";
            ListDateTime.Name = "ListDateTime";
            ListDateTime.ReadOnly = true;
            ListDateTime.Visible = false;
            // 
            // ListTime
            // 
            ListTime.HeaderText = "Time";
            ListTime.Name = "ListTime";
            ListTime.ReadOnly = true;
            // 
            // ListDate
            // 
            ListDate.HeaderText = "Date";
            ListDate.Name = "ListDate";
            ListDate.ReadOnly = true;
            // 
            // ListDelete
            // 
            ListDelete.HeaderText = "Delete";
            ListDelete.Name = "ListDelete";
            ListDelete.ReadOnly = true;
            ListDelete.Text = "X";
            // 
            // timezoneAddBtn
            // 
            timezoneAddBtn.Location = new Point(356, 12);
            timezoneAddBtn.Name = "timezoneAddBtn";
            timezoneAddBtn.Size = new Size(99, 23);
            timezoneAddBtn.TabIndex = 2;
            timezoneAddBtn.Text = "Add";
            timezoneAddBtn.UseVisualStyleBackColor = true;
            timezoneAddBtn.Click += timezoneAddBtn_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Multi Timezones Clock";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(94, 26);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(93, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 205);
            Controls.Add(timezoneAddBtn);
            Controls.Add(timezonesList);
            Controls.Add(timezonesComboBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Multi Timezone Clock";
            Load += Form1_Load;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)timezonesList).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox timezonesComboBox;
        private DataGridView timezonesList;
        private Button timezoneAddBtn;
        private System.Windows.Forms.Timer timer1;
        private DataGridViewTextBoxColumn ListTimezone;
        private DataGridViewTextBoxColumn ListDateTime;
        private DataGridViewTextBoxColumn ListTime;
        private DataGridViewTextBoxColumn ListDate;
        private DataGridViewButtonColumn ListDelete;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}