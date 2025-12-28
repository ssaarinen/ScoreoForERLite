using ScoreoForERLite.Lib;

namespace ScoreoForERLite.App
{
    public partial class MainForm : Form
    {
        private readonly ScoreoAppModel _model;
        private readonly AppSettings _appSettings = new();
        private readonly ResultDetailForm _detailForm;
        public MainForm()
        {
#if DEBUG
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fi-FI");
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
#endif
            _model = new ScoreoAppModel(this, _appSettings);
            _detailForm = new();
            InitializeComponent();
            UpdateIcons();
            dataGridView1.DataSource = _model.Results;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            BindSettings();
            UpdateI18N();

            // If debug build start automatically watching a test file from user desktop if it exists
#if DEBUG
            string testFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "scoreo.json");
            if (File.Exists(testFilePath))
            {
                _model.StartWatching(testFilePath);
            }
#endif
        }

        private void UpdateIcons()
        {
            openToolStripMenuItem.Image = SystemIcons.GetStockIcon(StockIconId.FolderOpen, StockIconOptions.SmallIcon).ToBitmap();
            settingsToolStripMenuItem.Image = SystemIcons.GetStockIcon(StockIconId.Application, StockIconOptions.SmallIcon).ToBitmap();
            exportToolStripMenuItem.Image = SystemIcons.GetStockIcon(StockIconId.DocumentWithAssociation, StockIconOptions.SmallIcon | StockIconOptions.LinkOverlay).ToBitmap();
            htmlToolStripMenuItem.Image = SystemIcons.GetStockIcon(StockIconId.MyNetwork, StockIconOptions.SmallIcon).ToBitmap();
            toolStripMenuExit.Image = SystemIcons.GetStockIcon(StockIconId.Delete, StockIconOptions.SmallIcon).ToBitmap();
            // Checked not visible w/ icons
            //toolStripMenuAlwaysOnTop.Image = SystemIcons.GetStockIcon(StockIconId.Stack, StockIconOptions.SmallIcon).ToBitmap();
            //toolStripMenuItemAutoShowLatest.Image = SystemIcons.GetStockIcon(StockIconId.AutoList, StockIconOptions.SmallIcon | StockIconOptions.Selected).ToBitmap();
            toolStripMenuAbout.Image = SystemIcons.GetStockIcon(StockIconId.Help, StockIconOptions.SmallIcon).ToBitmap();
        }

        private void UpdateI18N()
        {
            Text = Resources.I18N.AppName;
            fileToolStripMenuItem.Text = Resources.I18N.MenuItem_File;
            openToolStripMenuItem.Text = Resources.I18N.MenuItem_Open;
            settingsToolStripMenuItem.Text = Resources.I18N.MenuItem_Settings;
            exportToolStripMenuItem.Text = Resources.I18N.MenuItem_Export;
            htmlToolStripMenuItem.Text = Resources.I18N.MenuItem_Export_html;
            toolStripMenuExit.Text = Resources.I18N.MenuItem_Exit;
            viewToolStripMenuItem.Text = Resources.I18N.MenuItem_View;
            toolStripMenuAlwaysOnTop.Text = Resources.I18N.MenuItem_AlwaysOnTop;
            toolStripMenuItemAutoShowLatest.Text = Resources.I18N.MenuItem_AutoShowLatest;
            helpToolStripMenuItem.Text = Resources.I18N.MenuItem_Help;
            toolStripMenuAbout.Text = Resources.I18N.MenuItem_About;

            rankDataGridViewTextBoxColumn.HeaderText = Resources.I18N.MainGridHeader_Rank;
            fullNameDataGridViewTextBoxColumn.HeaderText = Resources.I18N.MainGridHeader_FullName;
            emitCodeDataGridViewTextBoxColumn.HeaderText = Resources.I18N.MainGridHeader_EmitCode;
            totalScoreDataGridViewTextBoxColumn.HeaderText = Resources.I18N.MainGridHeader_TotalScore;
            scoreDataGridViewTextBoxColumn.HeaderText = Resources.I18N.MainGridHeader_Score;
            penaltyScoreDataGridViewTextBoxColumn.HeaderText = Resources.I18N.MainGridHeader_PenaltyScore;
            eventTimeDataGridViewTextBoxColumn.HeaderText = Resources.I18N.MainGridHeader_EventTime;
            punchesDisplayDataGridViewTextBoxColumn.HeaderText = Resources.I18N.MainGridHeader_Punches;

            lastUpdatedToolStripStatusLabel.Text = Resources.I18N.StatusLabel_LastUpdated;
            resultsToolStripStatusLabel.Text = Resources.I18N.StatusLabel_Results;
            eventDetailsToolStripStatusLabel.Text = Resources.I18N.StatusLabel_EventDetails;

        }

        public void UpdateResults()
        {
            
            lastUpdatedToolStripStatus.Text = $"{DateTime.Now}";
            resultsToolStripStatus.Text = $"{_model.Results.Count}";
            eventDetailsToolStripStatus.Text = _model.LatestCompetition != null ?
                string.Join(" - ", new[] { _model.LatestCompetition.Date, _model.LatestCompetition.Name }.Where(item => !string.IsNullOrWhiteSpace(item))) : "";
            
            if (_model.LastUpdatedResultIndex >= 0)
            {
                dataGridView1.Rows[_model.LastUpdatedResultIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[_model.LastUpdatedResultIndex].Cells[0];

                if (_appSettings.AutoShowLatest)
                {
                    ShowResultDetails(_model.LastUpdatedResultIndex);
                }
            }
            else
            {
                dataGridView1.ClearSelection();
            }
        }

        private void ToolStripMenuAlwaysOnTop_Click(object sender, EventArgs e)
        {
            _appSettings.AlwaysOnTop = !_appSettings.AlwaysOnTop;
        }

        private void ToolStripMenuItemAutoShowLatest_Click(object sender, EventArgs e)
        {
            _appSettings.AutoShowLatest = !_appSettings.AutoShowLatest;
        }

        private void ToolStripMenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripMenuAbout_Click(object sender, EventArgs e)
        {
            using AboutBox1 aboutBox = new();
            aboutBox.ShowDialog();
        }

        private void BindSettings()
        {
            toolStripMenuAlwaysOnTop.DataBindings.Add("Checked", _appSettings, nameof(_appSettings.AlwaysOnTop));
            toolStripMenuItemAutoShowLatest.DataBindings.Add("Checked", _appSettings, nameof(_appSettings.AutoShowLatest));
            this.DataBindings.Add("TopMost", _appSettings, nameof(_appSettings.AlwaysOnTop));

            toolStripStatusValueFilename.DataBindings.Add("Text", _model, nameof(_model.CompetitionFileName));
            //maxTimeValue.DataBindings.Add("Text", _appSettings, nameof(_appSettings.MaxTimeSeconds));
            //penaltyIntervalValue.DataBindings.Add("Text", _appSettings, nameof(_appSettings.PenaltyIntervalSeconds));
            //penaltyPerIntervalValue.DataBindings.Add("Text", _appSettings, nameof(_appSettings.PenaltyPerInterval));
        }

        private void HtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_model.LatestCompetition != null)
            {
                using ExportToHtmlDialog exportDialog = new(_model.LatestCompetition);
                if (exportDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    var resultsView = _model.LatestResults.Select(item => item.AsResultsView(Resources.I18N.NoNameName)).ToList();

                    String html = ScoreOResultsImport.ImportResultsToHtml(Resources.I18N.Export_Results_Title + " " + exportDialog.ResultsTitle, resultsView);
                    File.WriteAllText(exportDialog.ResultsFilePath, html);
                    String htmls = ScoreOResultsImport.ImportSplitsToHtml(Resources.I18N.Export_Splits_Title + " " + exportDialog.ResultsTitle, resultsView.FindAll(item => item.ResultStatus != ResultStatus.NOTIME));
                    File.WriteAllText(exportDialog.SplitsFilePath, htmls);
                }
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = Resources.I18N.OpenCompetitionFile_Filter;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                _model.StartWatching(filePath);
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SettingsDialog settingsForm = new(_appSettings, _model?.LatestCompetition?.ExternalSettings);
            var result = settingsForm.ShowDialog();
            if (result == DialogResult.Cancel) // Settings dialog was closed from X
            {
                _model?.UpdateAppSettings(_appSettings);
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var data = e.Data.GetData(DataFormats.FileDrop);
                if (data is string[] files && files.Length > 0)
                {
                    _model.StartWatching(files[0]);
                }
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var data = e.Data.GetData(DataFormats.FileDrop);
                if (data is string[] files && files.Length > 0)
                {
                    var firstFile = files[0];
                    if (Path.HasExtension(firstFile) && Path.GetExtension(firstFile) == ".json")
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                }
            }

        }
        
        private void DataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowResultDetails(e.RowIndex);
        }

        private void ShowResultDetails(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < _model.Results.Count)
            {
                var entry = _model.Results[rowIndex];
                ScoreoResult? rogaResult = _model.LatestResults?.FirstOrDefault(r => r.Emit == entry.EmitCode);
                _detailForm.UpdateDetails(entry, rogaResult?.Punches ?? []);
                _detailForm.TopMost = this.TopMost;

                var childForms = Application.OpenForms.OfType<ResultDetailForm>().Count();
                if (childForms == 0)
                {
                    _detailForm.ShowDialog();
                }

            }
        }

        
    }
}
