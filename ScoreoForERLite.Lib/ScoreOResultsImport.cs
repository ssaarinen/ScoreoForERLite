using System.Text;

namespace ScoreoForERLite.Lib
{
    public class ScoreOResultsImport
    {
        private const string TEMPLATE = @"
<!DOCTYPE html>
<html lang=""{2}"">
<head>
  <meta charset=""utf-8"">
  <meta name=""Generator"" content=""ScoreO for EResults Lite""> 
  <title>{0}</title>
  <link href=""style.css"" rel=""stylesheet"" />
</head>
<body>
     <blockquote>
        <h2>{0}</h2>
        <hr>
        <br>
        <pre>{1}</pre>
     </blockquote>
  
</body>
</html>
";
        private const string RESULT_TEMPLATE = "{0,4} {1,-50} {2,10} {3,15} {4,8} {5,8}";

        private const string SPLIT_TEMPLATE = "{0,4} {1,-50}";
        private const string SPLIT_RESULT_TEMPLATE = "{0,10}";

        public static String ImportResultsToHtml(String title, List<ScoreoResult> results, string lang = "fi")
        {
            return String.Format(TEMPLATE, title, BuildResultsString(results), lang);
        }

        public static String ImportSplitsToHtml(String title, List<ScoreoResult> results, string lang = "fi")
        {
            return String.Format(TEMPLATE, title, BuildSplitResultsString(results), lang);
        }

        private static String BuildResultsString(List<ScoreoResult> results)
        {
            StringBuilder sb = new();
            sb.AppendLine(String.Format(RESULT_TEMPLATE, "Sija", "Nimi", "Pisteet", "Aika", "Sakko", "Tulos").TrimStart());
            sb.AppendLine(String.Join("\n", results.Select((result, index) =>
                String.Format(RESULT_TEMPLATE,
                    (index + 1) + ".",
                    result.Name,
                    result.Points,
                    ToHMS(result.EndTime),
                    result.Penalty,
                    result.Total))));
            return sb.ToString();
        }


        private static String BuildSplitResultsString(List<ScoreoResult> results)
        {

            StringBuilder splits = new();
            for (int i = 0; i < results.Count; i++)
            {
                var result = results[i];
                String template = SPLIT_TEMPLATE + string.Concat(Enumerable.Repeat(SPLIT_RESULT_TEMPLATE, result.Punches.Count));

                StringBuilder sb = new();
                sb.Append(String.Format(SPLIT_TEMPLATE, (i + 1) + ".", result.Name));
                sb.AppendLine(String.Join(" ", result.Punches.Select(p => String.Format(SPLIT_RESULT_TEMPLATE, $"{p.DisplayCode} {(p.ControlType == ControlType.Normal ? "" : "(" + p.Code + ")")}"))));
                sb.Append(String.Format(SPLIT_TEMPLATE, "", ""));
                sb.AppendLine(String.Join(" ", result.Punches.Select(p => String.Format(SPLIT_RESULT_TEMPLATE, p.SplitTimeSpan.FormatHMS()))));
                sb.Append(String.Format(SPLIT_TEMPLATE, "", ""));
                sb.AppendLine(String.Join(" ", result.Punches.Select(p => String.Format(SPLIT_RESULT_TEMPLATE, p.ElapsedTimeSpan.FormatHMS()))));
                sb.Append(String.Format(SPLIT_TEMPLATE, "", ""));
                sb.AppendLine(String.Join(" ", result.Punches.Select(p => String.Format(SPLIT_RESULT_TEMPLATE, $"{p.TotalScore} ({(p.Score > 0 ? "+" + p.Score : p.Score)})"))));

                splits.AppendLine(sb.ToString());
                splits.AppendLine();
            }
            return splits.ToString();
        }

        private static String ToHMS(long seconds)
        {
            if (seconds >= 3600 * 10)
            {
                return TimeSpan.FromSeconds(seconds).ToString(@"hh\.mm\.ss");
            }
            if (seconds >= 3600)
            {
                return TimeSpan.FromSeconds(seconds).ToString(@"h\.mm\.ss");
            }
            return TimeSpan.FromSeconds(seconds).ToString(@"mm\.ss");
        }

    }
}
