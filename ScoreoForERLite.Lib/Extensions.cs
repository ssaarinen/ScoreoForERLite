namespace ScoreoForERLite.Lib
{
    public static class Extensions
    {
        public static string FormatHMS(this TimeSpan timeSpan, bool optionalHours = true)
        {
            if (optionalHours && timeSpan.TotalHours >= 1)
                return timeSpan.ToString(@"hh\:mm\:ss");
            else
                return timeSpan.ToString(@"mm\:ss");
        }
    }
}
