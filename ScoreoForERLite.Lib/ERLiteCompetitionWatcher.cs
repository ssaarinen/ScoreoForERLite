using ScoreoForERLite.Lib.ERLiteModel;
using System.ComponentModel;

namespace ScoreoForERLite.Lib
{
    public class ERLiteCompetitionWatcher
    {
        public interface ICompetitionFileChangedListener
        {
            void OnCompetitionFileChanged(CompetitionFileChangedEvent evt);

            void OnCompetitionFileChangeError(CompetitionFileChangeErrorEvent evt);
        }

        

        public record CompetitionFileChangedEvent
        {
            public required ScoreoCompetition Competition { get; init; }

            public String CompetitionFile => Competition.File;
            public List<ScoreoResult> ScoreoResults => Competition.Results;

        }

        public record CompetitionFileChangeErrorEvent
        {
            public required Exception Exception { get; init; }
        }

        private readonly FileSystemWatcher _watcher;

        private readonly List<ICompetitionFileChangedListener> _listeners = [];
        private ScoreoResultOptions _options;
        private string? _competitionFile;

        public ERLiteCompetitionWatcher(ScoreoResultOptions options, ISynchronizeInvoke? syncObject = null)
        {
            _options = options;
            _watcher = new FileSystemWatcher
            {
                NotifyFilter = NotifyFilters.LastWrite
            };
            _watcher.Changed += OnCompetitionFileChanged;
            _watcher.SynchronizingObject = syncObject;

        }

        public void UpdateCompetitionFile(string fileName)
        {
            Stop();
            _competitionFile = fileName;
            var directoryName = Path.GetDirectoryName(fileName) ?? throw new ArgumentException("The fileName must include a directory path.", nameof(fileName));
            _watcher.Path = directoryName;
            _watcher.Filter = Path.GetFileName(fileName);
            Start();
        }

        public void UpdateResultOptions(ScoreoResultOptions opts)
        {
            if (_competitionFile == null)
            {
                _options = opts;
                return;
            }
            Stop();
            _options = opts;
            Start();
        }

        public void Start()
        {
            if (_competitionFile != null)
            {
                _watcher.EnableRaisingEvents = true;
                // Initial notification
                NotifyCompetitionFileChanged(_competitionFile);
            }
        }

        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
        }

        public void AddListener(ICompetitionFileChangedListener listener)
        {
            if(_listeners.Contains(listener))
            {
                return;
            }
            _listeners.Add(listener);
        }

        public void RemoveListener(ICompetitionFileChangedListener listener)
        {
            _listeners.Remove(listener);
        }


        private void OnCompetitionFileChanged(object sender, FileSystemEventArgs e)
        {
            NotifyCompetitionFileChanged(e.FullPath);

        }

        protected void NotifyCompetitionFileChanged(string competitionFile)
        {
            try
            {
                var json = File.ReadAllText(competitionFile);
                var competition = ERLiteCompetitionUtils.LoadEliteCompetitionJson(json);

                List<ScoreoResult> scoreoResults = [.. ERLiteCompetitionUtils.FlatResults(competition)
                    .Select(r => ERLiteCompetitionUtils.ToScoreoResult(r,
                    _options))
                    .OrderByDescending(item => item.Total).ThenBy(item => item.EndTime)
                    .Select((item, index) => item with { Rank = index + 1 })];

                var externalSettings = competition.Courses.Where(item => item.Controls.Count == 1 && item.Controls[0].ControlCode.StartsWith("@SV=")).Select(item => item.Controls[0].ControlCode).FirstOrDefault();

                ScoreoCompetition scoreoComp = new()
                {
                    File = competitionFile,
                    Name = competition.CompetitionData.Name,
                    Date = competition.CompetitionData.Date,
                    Location = competition.CompetitionData.Location,
                    Results = scoreoResults,
                    ExternalSettings = externalSettings
                };

                foreach (var listener in _listeners)
                {
                    listener.OnCompetitionFileChanged(new CompetitionFileChangedEvent { Competition = scoreoComp });
                }
            }
            catch (Exception ex)
            {
                foreach (var listener in _listeners)
                {
                    listener.OnCompetitionFileChangeError(new CompetitionFileChangeErrorEvent
                    {
                        Exception = ex
                    });
                }
            }
        }

        
    }
}
