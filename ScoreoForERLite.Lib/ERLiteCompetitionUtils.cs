using System.Text.Json;
using ScoreoForERLite.Lib.ERLiteModel;

namespace ScoreoForERLite.Lib
{
    public static class ERLiteCompetitionUtils
    {
        public static ERLiteCompetitionRoot LoadEliteCompetitionJson(string input)
        {
            return JsonSerializer.Deserialize<ERLiteCompetitionRoot>(input)
                ?? throw new InvalidOperationException("Deserialization returned null.");
        }


        public static List<ERLiteResultEntry> FlatResults(ERLiteCompetitionRoot competition)
        {
            return [.. competition.Courses.SelectMany(c => c.Results)];
        }

        public static int CalculatePenalty(long endTimeSeconds, int maxTimeSeconds, int penaltyIntervalSeconds, int penaltyAmount)
        {
            int over = (int)Math.Ceiling((endTimeSeconds - maxTimeSeconds) / (double)penaltyIntervalSeconds);
            return over > 0 ? over * penaltyAmount : 0;
        }

        public static string ToCsv(List<ScoreoResult> results, string separator = ";", string[]? headerNames = null)
        {
            var header = string.Join(separator, headerNames ?? ["Nimi", "Emit", "Seura", "Leimaukset", "Loppuaika", "Pisteet", "Sakko", "Lopputulos"]);
            var data = results.Select(r =>
                string.Join(separator, r.Name, r.Emit, r.Club ?? "", FormatPunches(r.Punches), FormatHms(r.EndTime), r.Points, r.Penalty, r.Total)
            );
            return header + "\n" + string.Join("\n", data);
        }

        public static string FormatPunches(List<ScoreoPunchDetail> punches)
        {
            return string.Join(", ", punches.Select(p =>
                $"{p.Code} split: {p.SplitTimeSpan.FormatHMS()} total: {p.ElapsedTimeSpan.FormatHMS()}"
            ));
        }

        public static string FormatHms(long seconds)
        {
            var t = TimeSpan.FromSeconds(seconds);
            return t.FormatHMS(optionalHours: true);
        }

        public static string FormatCode(string code, string zeroCode, string finishCode, string readerCode)
        {
            if(code == finishCode)
            {
                return "M";
            } else if (code == readerCode)
            {
                return "R";
            } else if (code == zeroCode)
            {
                return "L";
            }
                return code;
        }

        public static ControlType GetControlType(string code, string zeroCode, string finishCode, string readerCode)
        {
            if (code == finishCode)
            {
                return ControlType.Finish;
            }
            else if (code == readerCode)
            {
                return ControlType.Reader;
            }
            else if (code == zeroCode)
            {
                return ControlType.Zero;
            }
            return ControlType.Normal;
        }

        public static long CalculateFromZeroToStartTime(ERLiteResultEntry result, string finishCode)
        {
            // If Competitor has a start time, calculate the offset from zero to start
            if (result.Competitor.HasStartTime)
            {
                // If there is a finish punch, use that to calculate the difference otherwise we have to use the zero time
                long finishTime = result.Result.Punches.Find(item => item.PunchCode == finishCode)?.Time ?? result.Result.Time;
                return  finishTime - result.Result.Time;
            }
            return 0L;
        }

        public static ScoreoResult ToScoreoResult(ERLiteResultEntry data, ScoreoResultOptions opts)
        {
            long endTime = data.Result.Time;
            int points = 0;
            int penalty = -1 * CalculatePenalty(endTime, opts.MaxTimeSeconds, opts.PenaltyIntervalSeconds, opts.PenaltyAmount);

            var punches = new List<ScoreoPunchDetail>();
            var punchList = data.Result.Punches;
            string finishCode = opts.FinishControl;
            string readerCode = opts.ReaderControl;
            string zeroCode = opts.StartControl;
            string[] nonControlCodes = [ zeroCode, finishCode, readerCode ];

            // If there is less than 3 punches and zero, finish and reader are not on the card something fishy is happening
            if (punchList.Count >= nonControlCodes.Length && punchList.IntersectBy(nonControlCodes, item => item.PunchCode).Count() == nonControlCodes.Length)
            {
                // this is required if the competitor has a start time set to calculate first split correctly as it will be different from zero time
                long fromZeroToStart = CalculateFromZeroToStartTime(data, finishCode);
                var runningScore = 0;
                // flag to determine if there are punches after the finish control and before reader
                var finishControlReached = false;
                var prevTime = 0L;
                foreach (var punch in punchList)
                {
                    var isFinishCode = punch.PunchCode == finishCode;
                    var isZeroCode = punch.PunchCode == zeroCode;
                    var punched = new HashSet<string>(nonControlCodes);
                    var codeLegit = int.TryParse(punch.PunchCode, out int code);
                    var score = codeLegit && !punched.Contains(punch.PunchCode) && !finishControlReached && opts.ControlsToPoints.TryGetValue(code, out int value) ? value : 0;
                    runningScore += score;
                    punched.Add(punch.PunchCode);
                    punches.Add(new ScoreoPunchDetail
                    {
                        Code = punch.PunchCode,
                        DisplayCode = FormatCode(punch.PunchCode, zeroCode, finishCode, readerCode),
                        SplitTime = isZeroCode ? 0L : punch.Time - prevTime - fromZeroToStart, 
                        ElapsedTime = isZeroCode ? 0L :  punch.Time - fromZeroToStart, 
                        Score = isFinishCode ? penalty : score,
                        TotalScore = isFinishCode || finishControlReached ? runningScore + penalty : runningScore,
                        ControlType = GetControlType(punch.PunchCode, zeroCode, finishCode, readerCode)
                    });

                    
                    if(!finishControlReached && isFinishCode)
                    {
                        finishControlReached = true;
                    }
                    prevTime = punch.Time;
                }
                points = runningScore;
            }
            else
            {
                foreach (var punch in punchList)
                {
                    punches.Add(new ScoreoPunchDetail
                    {
                        Code = punch.PunchCode,
                        DisplayCode = punch.PunchCode,
                        SplitTime = 0,
                        ElapsedTime = 0,
                        Score = 0,
                        TotalScore = 0,
                        ControlType = GetControlType(punch.PunchCode, zeroCode, finishCode, readerCode),

                    });
                }
            }

            return new ScoreoResult
            {
                Name = data.Competitor.Name,
                Club = data.Competitor.Club,
                Emit = data.Competitor.Card.ToString(),
                NoNameInResults = data.Competitor.NoNameInResults,
                EndTime = endTime,
                Points = points,
                Penalty = penalty,
                Total = Math.Max(data.Result.Status == 0 ? points + penalty : 0, 0),
                Punches = punches,
                UpdatedTime = data.Result.Updated,
                ResultStatus = ScoreoModel.SafeResultStatusFromInt(data.Result.Status)
            };
        }
    }
}