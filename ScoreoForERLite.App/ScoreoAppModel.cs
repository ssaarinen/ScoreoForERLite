using ScoreoForERLite.Lib;
using System.ComponentModel;

namespace ScoreoForERLite.App
{
    internal class ScoreoAppModel : PropertyChangeNotifierBase, ERLiteCompetitionWatcher.ICompetitionFileChangedListener
    {
        public BindingList<UIResultEntry> Results { get; } = new BindingList<UIResultEntry>()
        {
            AllowNew = true,
            AllowRemove = true,
            AllowEdit = false,
        };

        public Boolean FileOk { get; internal set; } = false;

        public Boolean IsWatching { get; internal set; } = false;

        public string LastErrorMessage { get; internal set; } = "";


        public int LastUpdatedResultIndex { get; internal set; } = -1;

        private readonly ERLiteCompetitionWatcher _competitionWatcher;

        public List<ScoreoResult> LatestResults => LatestCompetition?.Results ?? [];

        public ScoreoCompetition? LatestCompetition { get; internal set; } = null;

        private string _competitionFileName = Resources.I18N.NoCompetitionFileName;
        public string CompetitionFileName
        {
            get => _competitionFileName;
            internal set
            {
                if (CompetitionFileName != value)
                {
                    _competitionFileName = value;
                    OnPropertyChanged();
                }
            }
        }

        private readonly MainForm _form;

        public ScoreoAppModel(MainForm sync, AppSettings settings)
        {
            _form = sync;
            var opts = AppSettingsToOptions(settings);
            _competitionWatcher = new ERLiteCompetitionWatcher(opts, sync);
        }

        public void StartWatching(string fileName)
        {
            UpdateFileName(fileName);

            
            _competitionWatcher.AddListener(this);
            _competitionWatcher.UpdateCompetitionFile(fileName);
        }

        private void UpdateFileName(string fileName)
        {
            if (File.Exists(fileName))
            {
                CompetitionFileName = fileName;
                this.FileOk = true;
                LastErrorMessage = "";
            }
            else
            {
                CompetitionFileName = "Error";
                this.FileOk = false;
                LastErrorMessage = $"File does not exist: {fileName}";
            }

        }

        public void UpdateAppSettings(AppSettings appSettings)
        {
            var opts = AppSettingsToOptions(appSettings);
            _competitionWatcher.UpdateResultOptions(opts);
        }

        private static ScoreoResultOptions AppSettingsToOptions(AppSettings appSettings)
        {
            return new ScoreoResultOptions
            {
                ControlsToPoints = ScoringFunctions.GetControlsToPoints(
                    appSettings.AllowedControls,
                    ScoringFunctions.GetFunctionByName(appSettings.ScoringFunctionName)),
                MaxTimeSeconds = appSettings.MaxTimeSeconds,
                PenaltyIntervalSeconds = appSettings.PenaltyIntervalSeconds,
                PenaltyAmount = appSettings.PenaltyPerInterval,
                FinishControl = appSettings.FinishControl,
                StartControl = appSettings.StartControl,
                ReaderControl = appSettings.ReaderControl
            };
        }


        public void OnCompetitionFileChanged(ERLiteCompetitionWatcher.CompetitionFileChangedEvent evt)
        {
            LatestCompetition = evt.Competition;
            var newResults = evt.ScoreoResults.Select(r => new UIResultEntry
            {
                FullName = r.Name,
                EmitCode = r.Emit,
                Score = r.Points,
                PenaltyScore = r.Penalty,
                EventTime = TimeSpan.FromSeconds(r.EndTime),
                Punches = [.. r.Punches.Select(p => p.Code)],
                TotalScore = r.Total,
                UpdatedTime = r.UpdatedTime,
                Rank = r.RankDisplay
            }).ToList();


            Results.Clear();
            newResults.ForEach(r => Results.Add(r));

            if (newResults.Count > 0)
            {
                var lastUpdatedResult = newResults.OrderByDescending(item => item.UpdatedTime).First();
                this.LastUpdatedResultIndex = newResults.FindIndex(item => item == lastUpdatedResult);

            }
            else
            {
                this.LastUpdatedResultIndex = -1;
            }

            _form.UpdateResults();
            LastErrorMessage = "";

        }

        public void OnCompetitionFileChangeError(ERLiteCompetitionWatcher.CompetitionFileChangeErrorEvent evt)
        {
            LastErrorMessage = $"Error processing competition file: {evt.Exception}";
        }
    }
}
