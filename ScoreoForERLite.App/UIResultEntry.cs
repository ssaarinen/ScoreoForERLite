namespace ScoreoForERLite.App
{
    public record UIResultEntry
    {
        public required string FullName { get; init; }

        public required string EmitCode { get; init; }
        public int Score { get; init; }
        public int PenaltyScore { get; init; }
        public TimeSpan EventTime { get; init; }
        public required string[] Punches { get; init; }

        public string PunchesDisplay => string.Join(", ", Punches);

        public int TotalScore { get; init; }

        public long UpdatedTime { get; init; }

        public required string Rank { get; init; }
    }
}
