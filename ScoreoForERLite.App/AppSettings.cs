using ScoreoForERLite.Lib;
using System.ComponentModel;
using System.Text.Json;


namespace ScoreoForERLite.App
{
    public class AppSettings : PropertyChangeNotifierBase
    {
        

        [Browsable(false)]
        public bool AlwaysOnTop
        {
            get => Properties.Settings.Default.AlwaysOnTop;
            set
            {
                if (Properties.Settings.Default.AlwaysOnTop != value)
                {
                    Properties.Settings.Default.AlwaysOnTop = value;
                    Properties.Settings.Default.Save();
                    OnPropertyChanged();
                }
            }
        }

        [Browsable(false)]
        public bool AutoShowLatest
        {
            get => Properties.Settings.Default.AutoOpenLatest;
            set
            {
                if (Properties.Settings.Default.AutoOpenLatest != value)
                {
                    Properties.Settings.Default.AutoOpenLatest = value;
                    Properties.Settings.Default.Save();
                    OnPropertyChanged();
                }
            }
        }


        [Browsable(false)]
        public int MaxTimeSeconds
        {
            get => Properties.Settings.Default.MaxTimeSeconds;
            set
            {
                if (Properties.Settings.Default.MaxTimeSeconds != value && value > 0)
                {
                    Properties.Settings.Default.MaxTimeSeconds = value;
                    Properties.Settings.Default.Save();
                    OnPropertyChanged();
                }
            }
        }
        
        [LocalizedDisplayName("Settings_MaxTime"), LocalizedDescription("Settings_MaxTime_Description"), LocalizedCategory("Settings_Group_Scoring")]//, Category("Pisteenlasku"), Description("Suorituksen maksimikesto, minkä yli menevästä ajasta lasketaan sakkoa.")]
        public TimeSpan MaxTime
        {
            get => TimeSpan.FromSeconds(MaxTimeSeconds);
            set => MaxTimeSeconds = (int)value.TotalSeconds;
        }

        [LocalizedDisplayName("Settings_PenaltyIntervalSeconds"), LocalizedDescription("Settings_PenaltyInterval_Description"), LocalizedCategory("Settings_Group_Scoring")]
        public int PenaltyIntervalSeconds
        {
            get => Properties.Settings.Default.PenaltyIntervalSeconds;
            set
            {
                if (Properties.Settings.Default.PenaltyIntervalSeconds != value && value > 0)
                {
                    Properties.Settings.Default.PenaltyIntervalSeconds = value;
                    Properties.Settings.Default.Save();
                    OnPropertyChanged();
                }
            }
        }

        [LocalizedDisplayName("Settings_PenaltyPerInterval"), LocalizedCategory("Settings_Group_Scoring"), LocalizedDescription("Settings_PenaltyPerInterval_Description")]
        public int PenaltyPerInterval
        {
            get => Properties.Settings.Default.PenaltyPerInterval;
            set
            {
                if (Properties.Settings.Default.PenaltyPerInterval != value && value >= 0)
                {
                    Properties.Settings.Default.PenaltyPerInterval = value;
                    Properties.Settings.Default.Save();
                    OnPropertyChanged();
                }
            }
        }

        [LocalizedDisplayName("Settings_ScoringFunctionName"), LocalizedCategory("Settings_Group_Scoring"), LocalizedDescription("Settings_ScoringFunctionName_Description")]
        [TypeConverter(typeof(ScoringFunctionTypeConverter))]
        public string ScoringFunctionName
        {
            get => Properties.Settings.Default.ScoringFunctionName; 
            set
            {
                if (Properties.Settings.Default.ScoringFunctionName != value && ScoringFunctions.GetAllFunctionNames().Contains(value))
                {
                    Properties.Settings.Default.ScoringFunctionName = value;
                    Properties.Settings.Default.Save();
                    OnPropertyChanged();
                }
            }
        }
        [LocalizedDisplayName("Settings_AllowedControls"), LocalizedCategory("Settings_Group_Scoring"), LocalizedDescription("Settings_AllowedControls_Description")]
        public string AllowedControls
        {
            get => Properties.Settings.Default.AllowedControls;
            set
            {
                if(Properties.Settings.Default.AllowedControls != value)
                {
                    Properties.Settings.Default.AllowedControls = value.Replace(" ", "");
                    Properties.Settings.Default.Save();
                    OnPropertyChanged();
                }
            }
        }


        [LocalizedDisplayName("Settings_StartControl"), LocalizedCategory("Settings_Group_General"), LocalizedDescription("Settings_StartControl_Description")]
        [ReadOnly(true)]
        public string StartControl {             
            get => Properties.Settings.Default.StartControl;
            set
            {
                if (Properties.Settings.Default.StartControl != value)
                {
                    Properties.Settings.Default.StartControl = value;
                    Properties.Settings.Default.Save();
                    OnPropertyChanged();
                }
            }
        }

        [LocalizedDisplayName("Settings_FinishControl"), LocalizedCategory("Settings_Group_General"), LocalizedDescription("Settings_FinishControl_Description")]
        public string FinishControl
        {
            get => Properties.Settings.Default.FinishControl;
            set
            {
                if (Properties.Settings.Default.FinishControl != value)
                {
                    Properties.Settings.Default.FinishControl = value;
                    Properties.Settings.Default.Save();
                    OnPropertyChanged();
                }
            }
        }

        [LocalizedDisplayName("Settings_ReaderControl"), LocalizedCategory("Settings_Group_General"), LocalizedDescription("Settings_ReaderControl_Description")]
        [ReadOnly(true)]
        public string ReaderControl
        {
            get => Properties.Settings.Default.ReaderControl;
            set
            {
                if (Properties.Settings.Default.ReaderControl != value)
                {
                    Properties.Settings.Default.ReaderControl = value;
                    Properties.Settings.Default.Save();
                    OnPropertyChanged();
                }
            }
        }


        public string ToSerialString()
        {
            var settingsDict = new Dictionary<string, string>
            {
                { "MTS", MaxTimeSeconds.ToString() },
                { "PIS", PenaltyIntervalSeconds.ToString() },
                { "PPI", PenaltyPerInterval.ToString() },
                { "SF", ScoringFunctionName },
                { "AC", AllowedControls },
                { "FC", FinishControl }
            };
            return SettingsSerializer.Serialize(settingsDict);
        }

        public void LoadFromSerialString(string serialString)
        {
            var settingsDict = SettingsSerializer.Deserialize(serialString) ?? throw new ArgumentException("Failed to deserialize settings string.");
            if (settingsDict.TryGetValue("MTS", out var mtsStr) && int.TryParse(mtsStr, out var mts))
            {
                MaxTimeSeconds = mts;
            }
            if (settingsDict.TryGetValue("PIS", out var pisStr) && int.TryParse(pisStr, out var pis))
            {
                PenaltyIntervalSeconds = pis;
            }
            if (settingsDict.TryGetValue("PPI", out var ppiStr) && int.TryParse(ppiStr, out var ppi))
            {
                PenaltyPerInterval = ppi;
            }
            if (settingsDict.TryGetValue("SF", out var sf))
            {
                ScoringFunctionName = sf;
            }
            if (settingsDict.TryGetValue("AC", out var ac))
            {
                AllowedControls = ac;
            }
            if (settingsDict.TryGetValue("FC", out var fc))
            {
                FinishControl = fc;
            }
        }

    }

    public class ScoringFunctionTypeConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext? context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext? context)
        {
            var functionNames = ScoringFunctions.GetAllFunctionNames();
            return new StandardValuesCollection(functionNames);
        }
    }

    public class LocalizedDisplayNameAttribute(string resourceKey) : DisplayNameAttribute
    {
        private readonly string _resourceKey = resourceKey;

        public override string DisplayName
        {
            get
            {
                var displayName = Resources.I18N.ResourceManager.GetString(_resourceKey);
                return displayName ?? $"[[{_resourceKey}]]";
            }
        }
    }

    public class LocalizedDescriptionAttribute(string resourceKey) : DescriptionAttribute
    {
        public override string Description
        {
            get
            {
                var description = Resources.I18N.ResourceManager.GetString(resourceKey);
                return description ?? $"[[{resourceKey}]]";
            }
        }
    }

    public class LocalizedCategoryAttribute(string resourceKey) : CategoryAttribute
    {
        protected override string GetLocalizedString(string value)
        {
            var res = Resources.I18N.ResourceManager.GetString(resourceKey);
            return res ?? $"[[{resourceKey}]]";
        }
    }
}
