
using System.ComponentModel;

namespace ScoreoForERLite.App
{
    public partial class SettingsDialog : Form
    {
        private readonly AppSettings _appSettings;
        private readonly string? _externalSettings;
        public SettingsDialog(AppSettings appSettings, string? externalSettings)
        {
            _appSettings = appSettings;
            _externalSettings = externalSettings;

            InitializeComponent();
            settingsGrid.SelectedObject = appSettings;
            UpdateI18N();

            appSettings.PropertyChanged += AppSettings_PropertyChanged;

            loadFromCompetitionToolStripMenuItem.Enabled = !string.IsNullOrEmpty(_externalSettings);

            UpdateSettinsString();
        }

        private void AppSettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            UpdateSettinsString();
        }

        private void UpdateSettinsString()
        {
            settingsToolStripStatusLabel.Text = _appSettings.ToSerialString();
            //MessageBox.Show(_externalSettings);
        }

        private void UpdateI18N()
        {
            Text = Resources.I18N.SettingsDialog_Title;
            actionsToolStripMenuItem.Text = Resources.I18N.SettingsDialog_Actions;
            loadFromCompetitionToolStripMenuItem.Text = Resources.I18N.SettingsDialog_LoadFromCompetition;
            copyToClipboardToolStripMenuItem.Text = Resources.I18N.SettingsDialog_CopyToClipboard;
        }

        private void CopyToClipboard()
        {
            Clipboard.SetText(_appSettings.ToSerialString());
            MessageBox.Show(Resources.I18N.SettingsCopiedClipboard);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _appSettings.PropertyChanged -= AppSettings_PropertyChanged;
        }

        private void SettingsToolStripStatusLabel_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        private void LoadFromCompetitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_externalSettings != null)
            {
                try {                    
                    _appSettings.LoadFromSerialString(_externalSettings);
                    settingsGrid.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format(Resources.I18N.Settings_LoadFromCompetition_Error, ex.Message));
                }
            }
        }

        private void CopyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }
    }
}
