using ScoreoForERLite.Lib;
using System.Globalization;

namespace ScoreoForERLite.App
{
    public partial class ExportToHtmlDialog : Form
    {
        public string ResultsFilePath => textBoxResultsFile.Text;
        public string SplitsFilePath => textBoxSplitsFile.Text;
        public string ResultsTitle => textBoxResultsTitle.Text;

        
        public ExportToHtmlDialog(ScoreoCompetition competition)
        {
            InitializeComponent();
            var baseFile = competition.File;
            if (!string.IsNullOrEmpty(baseFile) && File.Exists(baseFile))
            {
                var baseName = Path.GetFileNameWithoutExtension(baseFile);
                textBoxResultsFile.Text = Path.Combine(
                    Path.GetDirectoryName(baseFile) ?? string.Empty,
                    baseName + "-" + Resources.I18N.ExportToHtmlDialog_ResultsFileSuffix + ".html");
                textBoxSplitsFile.Text = Path.Combine(
                    Path.GetDirectoryName(baseFile) ?? string.Empty,
                    baseName + "-" + Resources.I18N.ExportToHtmlDialog_SplitsFileSuffix + ".html");
                textBoxResultsTitle.Text = $"{(String.IsNullOrWhiteSpace(competition.Date) ? DateTime.Now.ToShortDateString() : competition.Date)} {competition.Name}";
            }
            UpdateI18N();
        }

        private void UpdateI18N()
        {
            Text = Resources.I18N.ExportToHtmlDialog_Title;
            labelResultsFile.Text = Resources.I18N.ExportToHtmlDialog_ResultsFile;
            labelSplitsFile.Text = Resources.I18N.ExportToHtmlDialog_SplitsFile;
            labelResultsTitle.Text = Resources.I18N.ExportToHtmlDialog_ResultsTitle;
        }

        private void ButtonBrowseResults_Click(object sender, EventArgs e)
        {
            using var sfd = CreateSaveFileDialog(textBoxResultsFile.Text);
            if (sfd.ShowDialog() == DialogResult.OK)
                textBoxResultsFile.Text = sfd.FileName;
        }

        private void ButtonBrowseSplits_Click(object sender, EventArgs e)
        {
            using var sfd = CreateSaveFileDialog(textBoxSplitsFile.Text);
            if (sfd.ShowDialog() == DialogResult.OK)
                textBoxSplitsFile.Text = sfd.FileName;
        }

        private static SaveFileDialog CreateSaveFileDialog(string initialPath)
        {
            var sfd = new SaveFileDialog
            {
                RestoreDirectory = true,
                AddExtension = true,
                OverwritePrompt = true,
                Filter = Resources.I18N.ExportToHtmlDialog_Filter,
                InitialDirectory = Path.GetDirectoryName(initialPath) ?? Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                FileName = Path.GetFileName(initialPath)
            };
            return sfd;
        }
    }
}