using System.Text.Json;

namespace ScoreoForERLite.Lib
{
    public static class SettingsSerializer
    {
        public static readonly string SettingsPrefix = "@SV=1;";

        public static string Serialize(Dictionary<string, string> settings)
        {
            var settingsStr = JsonSerializer.Serialize(settings);
            var settingsBase64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(settingsStr));
            return SettingsPrefix + settingsBase64; ;
        }

        public static Dictionary<string, string> Deserialize(string serializedSettings)
        {
            if (!serializedSettings.StartsWith(SettingsPrefix))
            {
                throw new ArgumentException("Invalid settings string format.");
            }
            var base64Str = serializedSettings.Substring(SettingsPrefix.Length);
            var jsonStr = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64Str));
            var result = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStr);
            return result is not null ? result : throw new InvalidOperationException("Deserialization resulted in null.");
        }

    }
}