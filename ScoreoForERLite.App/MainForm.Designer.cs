namespace ScoreoForERLite.App
{
    partial class MainForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            htmlToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuExit = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuAlwaysOnTop = new ToolStripMenuItem();
            toolStripMenuItemAutoShowLatest = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            instructionsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuAbout = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusValueFilename = new ToolStripStatusLabel();
            lastUpdatedToolStripStatusLabel = new ToolStripStatusLabel();
            lastUpdatedToolStripStatus = new ToolStripStatusLabel();
            eventDetailsToolStripStatusLabel = new ToolStripStatusLabel();
            eventDetailsToolStripStatus = new ToolStripStatusLabel();
            resultsToolStripStatusLabel = new ToolStripStatusLabel();
            resultsToolStripStatus = new ToolStripStatusLabel();
            dataGridView1 = new DataGridView();
            rankDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emitCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalScoreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            scoreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            penaltyScoreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            eventTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            punchesDisplayDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            uIResultEntryBindingSource1 = new BindingSource(components);
            uIResultEntryBindingSource = new BindingSource(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uIResultEntryBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uIResultEntryBindingSource).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 3, 0, 3);
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(1637, 35);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, settingsToolStripMenuItem, exportToolStripMenuItem, toolStripMenuExit });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(178, 34);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(178, 34);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += SettingsToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { htmlToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(178, 34);
            exportToolStripMenuItem.Text = "Export";
            // 
            // htmlToolStripMenuItem
            // 
            htmlToolStripMenuItem.Name = "htmlToolStripMenuItem";
            htmlToolStripMenuItem.Size = new Size(153, 34);
            htmlToolStripMenuItem.Text = "Html";
            htmlToolStripMenuItem.Click += HtmlToolStripMenuItem_Click;
            // 
            // toolStripMenuExit
            // 
            toolStripMenuExit.Name = "toolStripMenuExit";
            toolStripMenuExit.Size = new Size(178, 34);
            toolStripMenuExit.Text = "Exit";
            toolStripMenuExit.Click += ToolStripMenuExit_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuAlwaysOnTop, toolStripMenuItemAutoShowLatest });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(65, 29);
            viewToolStripMenuItem.Text = "View";
            // 
            // toolStripMenuAlwaysOnTop
            // 
            toolStripMenuAlwaysOnTop.CheckOnClick = true;
            toolStripMenuAlwaysOnTop.Name = "toolStripMenuAlwaysOnTop";
            toolStripMenuAlwaysOnTop.Size = new Size(247, 34);
            toolStripMenuAlwaysOnTop.Text = "Always on top";
            toolStripMenuAlwaysOnTop.Click += ToolStripMenuAlwaysOnTop_Click;
            // 
            // toolStripMenuItemAutoShowLatest
            // 
            toolStripMenuItemAutoShowLatest.CheckOnClick = true;
            toolStripMenuItemAutoShowLatest.Name = "toolStripMenuItemAutoShowLatest";
            toolStripMenuItemAutoShowLatest.Size = new Size(247, 34);
            toolStripMenuItemAutoShowLatest.Text = "Auto show latest";
            toolStripMenuItemAutoShowLatest.Click += ToolStripMenuItemAutoShowLatest_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { instructionsToolStripMenuItem, toolStripMenuAbout });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "Help";
            // 
            // instructionsToolStripMenuItem
            // 
            instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            instructionsToolStripMenuItem.Size = new Size(270, 34);
            instructionsToolStripMenuItem.Text = "Instructions";
            instructionsToolStripMenuItem.Click += InstructionsToolStripMenuItem_Click;
            // 
            // toolStripMenuAbout
            // 
            toolStripMenuAbout.Name = "toolStripMenuAbout";
            toolStripMenuAbout.Size = new Size(270, 34);
            toolStripMenuAbout.Text = "About";
            toolStripMenuAbout.Click += ToolStripMenuAbout_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusValueFilename, lastUpdatedToolStripStatusLabel, lastUpdatedToolStripStatus, eventDetailsToolStripStatusLabel, eventDetailsToolStripStatus, resultsToolStripStatusLabel, resultsToolStripStatus });
            statusStrip1.Location = new Point(0, 774);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 18, 0);
            statusStrip1.Size = new Size(1637, 32);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusValueFilename
            // 
            toolStripStatusValueFilename.Name = "toolStripStatusValueFilename";
            toolStripStatusValueFilename.Size = new Size(160, 25);
            toolStripStatusValueFilename.Text = "Ei kilpailutiedostoa";
            // 
            // lastUpdatedToolStripStatusLabel
            // 
            lastUpdatedToolStripStatusLabel.Name = "lastUpdatedToolStripStatusLabel";
            lastUpdatedToolStripStatusLabel.Size = new Size(119, 25);
            lastUpdatedToolStripStatusLabel.Text = "Last updated:";
            // 
            // lastUpdatedToolStripStatus
            // 
            lastUpdatedToolStripStatus.Name = "lastUpdatedToolStripStatus";
            lastUpdatedToolStripStatus.Size = new Size(44, 25);
            lastUpdatedToolStripStatus.Text = "N/A";
            // 
            // eventDetailsToolStripStatusLabel
            // 
            eventDetailsToolStripStatusLabel.Name = "eventDetailsToolStripStatusLabel";
            eventDetailsToolStripStatusLabel.Size = new Size(103, 25);
            eventDetailsToolStripStatusLabel.Text = "Tapahtuma:";
            // 
            // eventDetailsToolStripStatus
            // 
            eventDetailsToolStripStatus.Name = "eventDetailsToolStripStatus";
            eventDetailsToolStripStatus.Size = new Size(83, 25);
            eventDetailsToolStripStatus.Text = "Tiedot ....";
            // 
            // resultsToolStripStatusLabel
            // 
            resultsToolStripStatusLabel.Name = "resultsToolStripStatusLabel";
            resultsToolStripStatusLabel.Size = new Size(71, 25);
            resultsToolStripStatusLabel.Text = "Results:";
            // 
            // resultsToolStripStatus
            // 
            resultsToolStripStatus.Name = "resultsToolStripStatus";
            resultsToolStripStatus.Size = new Size(22, 25);
            resultsToolStripStatus.Text = "0";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.GradientActiveCaption;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { rankDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, emitCodeDataGridViewTextBoxColumn, totalScoreDataGridViewTextBoxColumn, scoreDataGridViewTextBoxColumn, penaltyScoreDataGridViewTextBoxColumn, eventTimeDataGridViewTextBoxColumn, punchesDisplayDataGridViewTextBoxColumn });
            dataGridView1.DataSource = uIResultEntryBindingSource1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 35);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1637, 739);
            dataGridView1.TabIndex = 0;
            // 
            // rankDataGridViewTextBoxColumn
            // 
            rankDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            rankDataGridViewTextBoxColumn.DataPropertyName = "Rank";
            rankDataGridViewTextBoxColumn.HeaderText = "#";
            rankDataGridViewTextBoxColumn.MinimumWidth = 8;
            rankDataGridViewTextBoxColumn.Name = "rankDataGridViewTextBoxColumn";
            rankDataGridViewTextBoxColumn.ReadOnly = true;
            rankDataGridViewTextBoxColumn.Width = 8;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            fullNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn.HeaderText = "Nimi";
            fullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            fullNameDataGridViewTextBoxColumn.Width = 105;
            // 
            // emitCodeDataGridViewTextBoxColumn
            // 
            emitCodeDataGridViewTextBoxColumn.DataPropertyName = "EmitCode";
            emitCodeDataGridViewTextBoxColumn.HeaderText = "Emit";
            emitCodeDataGridViewTextBoxColumn.MinimumWidth = 8;
            emitCodeDataGridViewTextBoxColumn.Name = "emitCodeDataGridViewTextBoxColumn";
            emitCodeDataGridViewTextBoxColumn.ReadOnly = true;
            emitCodeDataGridViewTextBoxColumn.Width = 150;
            // 
            // totalScoreDataGridViewTextBoxColumn
            // 
            totalScoreDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            totalScoreDataGridViewTextBoxColumn.DataPropertyName = "TotalScore";
            totalScoreDataGridViewTextBoxColumn.HeaderText = "Tulos";
            totalScoreDataGridViewTextBoxColumn.MinimumWidth = 8;
            totalScoreDataGridViewTextBoxColumn.Name = "totalScoreDataGridViewTextBoxColumn";
            totalScoreDataGridViewTextBoxColumn.ReadOnly = true;
            totalScoreDataGridViewTextBoxColumn.Width = 110;
            // 
            // scoreDataGridViewTextBoxColumn
            // 
            scoreDataGridViewTextBoxColumn.DataPropertyName = "Score";
            scoreDataGridViewTextBoxColumn.HeaderText = "Pisteet";
            scoreDataGridViewTextBoxColumn.MinimumWidth = 8;
            scoreDataGridViewTextBoxColumn.Name = "scoreDataGridViewTextBoxColumn";
            scoreDataGridViewTextBoxColumn.ReadOnly = true;
            scoreDataGridViewTextBoxColumn.Width = 150;
            // 
            // penaltyScoreDataGridViewTextBoxColumn
            // 
            penaltyScoreDataGridViewTextBoxColumn.DataPropertyName = "PenaltyScore";
            penaltyScoreDataGridViewTextBoxColumn.HeaderText = "Sakko";
            penaltyScoreDataGridViewTextBoxColumn.MinimumWidth = 8;
            penaltyScoreDataGridViewTextBoxColumn.Name = "penaltyScoreDataGridViewTextBoxColumn";
            penaltyScoreDataGridViewTextBoxColumn.ReadOnly = true;
            penaltyScoreDataGridViewTextBoxColumn.Width = 150;
            // 
            // eventTimeDataGridViewTextBoxColumn
            // 
            eventTimeDataGridViewTextBoxColumn.DataPropertyName = "EventTime";
            eventTimeDataGridViewTextBoxColumn.HeaderText = "Aika";
            eventTimeDataGridViewTextBoxColumn.MinimumWidth = 8;
            eventTimeDataGridViewTextBoxColumn.Name = "eventTimeDataGridViewTextBoxColumn";
            eventTimeDataGridViewTextBoxColumn.ReadOnly = true;
            eventTimeDataGridViewTextBoxColumn.Width = 150;
            // 
            // punchesDisplayDataGridViewTextBoxColumn
            // 
            punchesDisplayDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            punchesDisplayDataGridViewTextBoxColumn.DataPropertyName = "PunchesDisplay";
            punchesDisplayDataGridViewTextBoxColumn.HeaderText = "Leimaukset";
            punchesDisplayDataGridViewTextBoxColumn.MinimumWidth = 8;
            punchesDisplayDataGridViewTextBoxColumn.Name = "punchesDisplayDataGridViewTextBoxColumn";
            punchesDisplayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uIResultEntryBindingSource1
            // 
            uIResultEntryBindingSource1.DataSource = typeof(UIResultEntry);
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1637, 806);
            Controls.Add(dataGridView1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "EResultsScoreO";
            DragDrop += MainForm_DragDrop;
            DragEnter += MainForm_DragEnter;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)uIResultEntryBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)uIResultEntryBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private DataGridView dataGridView1;
        private BindingSource uIResultEntryBindingSource;
        private ToolStripStatusLabel lastUpdatedToolStripStatusLabel;
        private ToolStripStatusLabel lastUpdatedToolStripStatus;
        private ToolStripStatusLabel resultsToolStripStatusLabel;
        private ToolStripStatusLabel resultsToolStripStatus;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuExit;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuAlwaysOnTop;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuAbout;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem htmlToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private BindingSource uIResultEntryBindingSource1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusValueFilename;
        private ToolStripMenuItem toolStripMenuItemAutoShowLatest;
        private ToolStripStatusLabel eventDetailsToolStripStatusLabel;
        private ToolStripStatusLabel eventDetailsToolStripStatus;
        private DataGridViewTextBoxColumn rankDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emitCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalScoreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn scoreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn penaltyScoreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn eventTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn punchesDisplayDataGridViewTextBoxColumn;
        private ToolStripMenuItem instructionsToolStripMenuItem;
    }
}
