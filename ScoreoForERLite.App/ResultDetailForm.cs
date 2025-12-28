using ScoreoForERLite.Lib;

namespace ScoreoForERLite.App
{
    public partial class ResultDetailForm : Form
    {
        private readonly string titleTemplate;
        public ResultDetailForm()
        {
            InitializeComponent();
            titleTemplate = this.Text;
            UpdateI18N();

        }

        private void UpdateI18N()
        {
            labelRank.Text = Resources.I18N.ResultDetails_Rank + ":";
            labelTotalScore.Text = Resources.I18N.MainGridHeader_Score + ":";
            labelTime.Text = Resources.I18N.MainGridHeader_EventTime + ":";
            labelPenalty.Text = Resources.I18N.MainGridHeader_PenaltyScore + ":";

            punchCodeDataGridViewTextBoxColumn.HeaderText = Resources.I18N.ResultGridHeader_PunchCode;
            scoreDataGridViewTextBoxColumn.HeaderText = Resources.I18N.MainGridHeader_Score;
            splitTimeDataGridViewTextBoxColumn.HeaderText = Resources.I18N.ResultGridHeader_SplitTime;
            elapsedTimeDataGridViewTextBoxColumn.HeaderText = Resources.I18N.MainGridHeader_EventTime;
            totalScoreDataGridViewTextBoxColumn.HeaderText = Resources.I18N.ResultGridHeader_TotalScore;
        }

        public void UpdateDetails(UIResultEntry entry, List<ScoreoPunchDetail> punches)
        {
            var personInfo = titleTemplate.Replace("{name}", entry?.FullName ?? "").Replace("{emit}", entry?.EmitCode ?? "");
            Text = Resources.I18N.ResultDetails_Title + " " + personInfo;
            // Basic info
            labelNameValue.Text = personInfo;
            labelRankValue.Text = entry != null ? entry.Rank + "." : "";
            labelTotalScoreValue.Text = entry != null ? entry.TotalScore.ToString() : "";
            labelTimeValue.Text = entry != null ? entry.EventTime.FormatHMS() : "";
            labelPenaltyValue.Text = (entry?.PenaltyScore ?? 0).ToString();

            // Punches grid
            dataGridViewPunches.Rows.Clear();
            dataGridViewPunches.SuspendLayout();
            foreach (var punch in punches)
            {
                var idx = dataGridViewPunches.Rows.Add();
                var cell = 0;
                dataGridViewPunches.Rows[idx].Cells[cell++].Value = punch.DisplayCode;
                dataGridViewPunches.Rows[idx].Cells[cell++].Value = punch.Score;
                dataGridViewPunches.Rows[idx].Cells[cell++].Value = punch.SplitTimeSpan.FormatHMS();
                dataGridViewPunches.Rows[idx].Cells[cell++].Value = punch.ElapsedTimeSpan.FormatHMS();
                dataGridViewPunches.Rows[idx].Cells[cell++].Value = punch.TotalScore;
            }
            dataGridViewPunches.ResumeLayout();

        }

        private void ResultDetailForm_LocationChanged(object sender, EventArgs e)
        {
            // remember location
            this.StartPosition = FormStartPosition.Manual;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}