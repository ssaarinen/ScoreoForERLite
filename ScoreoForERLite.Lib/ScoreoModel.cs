namespace ScoreoForERLite.Lib
{

    public static class ScoreoModel
    {
        public static ResultStatus SafeResultStatusFromInt(int value)
        {
            if (Enum.IsDefined(typeof(ResultStatus), value))
            {
                return (ResultStatus)value;
            }
            return ResultStatus.OK;
        }
    }

    public record ScoreoCompetition
    {
        public required string File { get; init; }
        public required string Name { get; init; }

        public required string Date { get; init; }

        public required string Location { get; init; }
        public required List<ScoreoResult> Results { get; init; }

        public string? ExternalSettings { get; init; }
    }

    public record ScoreoResult
    {
        public required string Name { get; init; }
        public required string Club { get; init; }
        public required string Emit { get; init; }
        public required List<ScoreoPunchDetail> Punches { get; init; }
        public long EndTime { get; init; }
        public int Points { get; init; }
        public int Penalty { get; init; }
        public int Total { get; init; }

        public int Rank { get; init; } = 0;

        public long UpdatedTime { get; init; }

        public bool NoNameInResults { get; init; } = false;

        public ResultStatus ResultStatus { get; init; } = ResultStatus.OK;

        public string RankDisplay => ResultStatus == ResultStatus.OK ? Rank.ToString() : ResultStatus.ToString();
            
        public ScoreoResult AsResultsView(string anonymizedName)
        {
            return NoNameInResults ?  this with { Name = anonymizedName } : this;
        }
    }

    public enum ResultStatus
    {
        OK, DSQ, DNF, DNS, NOTIME
    }
    public record ScoreoPunchDetail
    {
        public required string Code { get; init; }

        public required string DisplayCode { get; init; }
        public long SplitTime { get; init; }
        public long ElapsedTime { get; init; }

        public int Score { get; init; }

        public int TotalScore { get; init; }

        public ControlType ControlType { get; init; }

        public TimeSpan ElapsedTimeSpan => TimeSpan.FromSeconds(ElapsedTime);
        public TimeSpan SplitTimeSpan => TimeSpan.FromSeconds(SplitTime);
    }

    public enum ControlType
    {
        Normal,
        Finish,
        Reader,
        Zero
    }

    public record ScoreoResultOptions
    {
        public required Dictionary<int, int> ControlsToPoints { get; init; }
        public int MaxTimeSeconds { get; init; } = 3600;
        public int PenaltyIntervalSeconds { get; init; } = 60;
        public int PenaltyAmount { get; init; } = 10;

        public string StartControl { get; init; } = "0";

        public string FinishControl { get; init; } = "100";

        public string ReaderControl { get; init; } = "250";
    }
}