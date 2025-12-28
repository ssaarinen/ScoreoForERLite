namespace ScoreoForERLite.App
{
    partial class ResultDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelTotalScore;
        private DataGridView dataGridViewPunches;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            labelTotalScore = new Label();
            dataGridViewPunches = new DataGridView();
            punchCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            scoreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            splitTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            elapsedTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalScoreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            labelNameValue = new Label();
            labelPenaltyValue = new Label();
            labelPenalty = new Label();
            labelRankValue = new Label();
            labelRank = new Label();
            labelTimeValue = new Label();
            labelTime = new Label();
            labelTotalScoreValue = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPunches).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelTotalScore
            // 
            labelTotalScore.AutoSize = true;
            labelTotalScore.Font = new Font("Segoe UI", 16F);
            labelTotalScore.Location = new Point(3, 106);
            labelTotalScore.Name = "labelTotalScore";
            labelTotalScore.Size = new Size(123, 45);
            labelTotalScore.TabIndex = 2;
            labelTotalScore.Text = "Pisteet:";
            // 
            // dataGridViewPunches
            // 
            dataGridViewPunches.AllowUserToAddRows = false;
            dataGridViewPunches.AllowUserToDeleteRows = false;
            dataGridViewPunches.AllowUserToResizeColumns = false;
            dataGridViewPunches.AllowUserToResizeRows = false;
            dataGridViewPunches.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewPunches.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewPunches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPunches.Columns.AddRange(new DataGridViewColumn[] { punchCodeDataGridViewTextBoxColumn, scoreDataGridViewTextBoxColumn, splitTimeDataGridViewTextBoxColumn, elapsedTimeDataGridViewTextBoxColumn, totalScoreDataGridViewTextBoxColumn });
            dataGridViewPunches.Location = new Point(3, 162);
            dataGridViewPunches.Name = "dataGridViewPunches";
            dataGridViewPunches.ReadOnly = true;
            dataGridViewPunches.RowHeadersWidth = 62;
            dataGridViewPunches.ScrollBars = ScrollBars.Vertical;
            dataGridViewPunches.Size = new Size(1129, 796);
            dataGridViewPunches.TabIndex = 3;
            // 
            // punchCodeDataGridViewTextBoxColumn
            // 
            punchCodeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            punchCodeDataGridViewTextBoxColumn.HeaderText = "Rastikoodi";
            punchCodeDataGridViewTextBoxColumn.MinimumWidth = 8;
            punchCodeDataGridViewTextBoxColumn.Name = "punchCodeDataGridViewTextBoxColumn";
            punchCodeDataGridViewTextBoxColumn.ReadOnly = true;
            punchCodeDataGridViewTextBoxColumn.Width = 171;
            // 
            // scoreDataGridViewTextBoxColumn
            // 
            scoreDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            scoreDataGridViewTextBoxColumn.HeaderText = "Pisteet";
            scoreDataGridViewTextBoxColumn.MinimumWidth = 8;
            scoreDataGridViewTextBoxColumn.Name = "scoreDataGridViewTextBoxColumn";
            scoreDataGridViewTextBoxColumn.ReadOnly = true;
            scoreDataGridViewTextBoxColumn.Width = 127;
            // 
            // splitTimeDataGridViewTextBoxColumn
            // 
            splitTimeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            splitTimeDataGridViewTextBoxColumn.HeaderText = "Väliaika";
            splitTimeDataGridViewTextBoxColumn.MinimumWidth = 8;
            splitTimeDataGridViewTextBoxColumn.Name = "splitTimeDataGridViewTextBoxColumn";
            splitTimeDataGridViewTextBoxColumn.ReadOnly = true;
            splitTimeDataGridViewTextBoxColumn.Width = 137;
            // 
            // elapsedTimeDataGridViewTextBoxColumn
            // 
            elapsedTimeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            elapsedTimeDataGridViewTextBoxColumn.HeaderText = "Aika";
            elapsedTimeDataGridViewTextBoxColumn.MinimumWidth = 8;
            elapsedTimeDataGridViewTextBoxColumn.Name = "elapsedTimeDataGridViewTextBoxColumn";
            elapsedTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalScoreDataGridViewTextBoxColumn
            // 
            totalScoreDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            totalScoreDataGridViewTextBoxColumn.HeaderText = "Kokonaistulos";
            totalScoreDataGridViewTextBoxColumn.MinimumWidth = 8;
            totalScoreDataGridViewTextBoxColumn.Name = "totalScoreDataGridViewTextBoxColumn";
            totalScoreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelNameValue);
            panel1.Controls.Add(labelPenaltyValue);
            panel1.Controls.Add(labelPenalty);
            panel1.Controls.Add(labelRankValue);
            panel1.Controls.Add(labelRank);
            panel1.Controls.Add(labelTimeValue);
            panel1.Controls.Add(labelTime);
            panel1.Controls.Add(labelTotalScoreValue);
            panel1.Controls.Add(labelTotalScore);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1129, 153);
            panel1.TabIndex = 0;
            // 
            // labelNameValue
            // 
            labelNameValue.AutoSize = true;
            labelNameValue.Font = new Font("Segoe UI", 16F);
            labelNameValue.Location = new Point(3, 0);
            labelNameValue.Name = "labelNameValue";
            labelNameValue.Size = new Size(96, 45);
            labelNameValue.TabIndex = 15;
            labelNameValue.Text = "Tulos";
            // 
            // labelPenaltyValue
            // 
            labelPenaltyValue.AutoSize = true;
            labelPenaltyValue.Font = new Font("Segoe UI", 16F);
            labelPenaltyValue.Location = new Point(547, 106);
            labelPenaltyValue.Name = "labelPenaltyValue";
            labelPenaltyValue.Size = new Size(104, 45);
            labelPenaltyValue.TabIndex = 13;
            labelPenaltyValue.Text = "Sakko";
            // 
            // labelPenalty
            // 
            labelPenalty.AutoSize = true;
            labelPenalty.Font = new Font("Segoe UI", 16F);
            labelPenalty.Location = new Point(374, 106);
            labelPenalty.Name = "labelPenalty";
            labelPenalty.Size = new Size(111, 45);
            labelPenalty.TabIndex = 12;
            labelPenalty.Text = "Sakko:";
            // 
            // labelRankValue
            // 
            labelRankValue.AutoSize = true;
            labelRankValue.Font = new Font("Segoe UI", 16F);
            labelRankValue.Location = new Point(176, 54);
            labelRankValue.Name = "labelRankValue";
            labelRankValue.Size = new Size(123, 45);
            labelRankValue.TabIndex = 11;
            labelRankValue.Text = "Sijoitus";
            // 
            // labelRank
            // 
            labelRank.AutoSize = true;
            labelRank.Font = new Font("Segoe UI", 16F);
            labelRank.Location = new Point(3, 54);
            labelRank.Name = "labelRank";
            labelRank.Size = new Size(130, 45);
            labelRank.TabIndex = 10;
            labelRank.Text = "Sijoitus:";
            // 
            // labelTimeValue
            // 
            labelTimeValue.AutoSize = true;
            labelTimeValue.Font = new Font("Segoe UI", 16F);
            labelTimeValue.Location = new Point(547, 54);
            labelTimeValue.Name = "labelTimeValue";
            labelTimeValue.Size = new Size(81, 45);
            labelTimeValue.TabIndex = 7;
            labelTimeValue.Text = "Aika";
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Segoe UI", 16F);
            labelTime.Location = new Point(374, 54);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(88, 45);
            labelTime.TabIndex = 6;
            labelTime.Text = "Aika:";
            // 
            // labelTotalScoreValue
            // 
            labelTotalScoreValue.AutoSize = true;
            labelTotalScoreValue.Font = new Font("Segoe UI", 16F);
            labelTotalScoreValue.Location = new Point(176, 106);
            labelTotalScoreValue.Name = "labelTotalScoreValue";
            labelTotalScoreValue.Size = new Size(116, 45);
            labelTotalScoreValue.TabIndex = 5;
            labelTotalScoreValue.Text = "Pisteet";
            // 
            // ResultDetailForm
            // 
            AutoScroll = true;
            ClientSize = new Size(1135, 964);
            Controls.Add(panel1);
            Controls.Add(dataGridViewPunches);
            Font = new Font("Segoe UI", 12F);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(800, 0);
            Name = "ResultDetailForm";
            Padding = new Padding(3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "{name} ({emit})";
            LocationChanged += ResultDetailForm_LocationChanged;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPunches).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }
        private Panel panel1;
        private Label labelTotalScoreValue;
        private Label labelRankValue;
        private Label labelRank;
        private Label labelTimeValue;
        private Label labelTime;
        private Label labelPenaltyValue;
        private Label labelPenalty;
        private Label labelNameValue;
        private DataGridViewTextBoxColumn punchCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn scoreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn splitTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn elapsedTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalScoreDataGridViewTextBoxColumn;
    }
}