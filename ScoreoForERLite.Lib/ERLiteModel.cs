using System.Text.Json.Serialization;

namespace ScoreoForERLite.Lib.ERLiteModel
{

    public class ERLiteCompetitionRoot
    {
        [JsonPropertyName("CompetitionData")]
        public required ERLiteCompetition CompetitionData { get; set; }

        [JsonPropertyName("Courses")]
        public required List<ERLiteCourse> Courses { get; set; }

        public override string ToString()
        {
            var coursesStr = Courses != null && Courses.Count > 0
                ? string.Join("\n\n", Courses.Select(c => c.ToString()))
                : "No Courses";
            return $"{CompetitionData}\n\n{coursesStr}";
        }
    }

    public class ERLiteCompetition
    {
        public required string CompetitionId { get; set; }
        public required string Date { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }

        public override string ToString()
        {
            return $"Competition: {Name} (ID: {CompetitionId}), Date: {Date}, Location: {Location}";
        }
    }

    public class ERLiteCourse
    {
        [JsonPropertyName("Name")]
        public required string Name { get; set; }

        [JsonPropertyName("Results")]
        public required List<ERLiteResultEntry> Results { get; set; }

        [JsonPropertyName("Controls")]
        public required List<ERLiteControl> Controls { get; set; }

        public override string ToString()
        {
            var resultsStr = Results != null && Results.Count > 0
                ? string.Join("\n", Results.Select(r => r.ToString()))
                : "No Results";
            return $"Course: {Name}\n{resultsStr}";
        }
    }

    public class ERLiteControl
    {
        [JsonPropertyName("ControlCode")]
        public required string ControlCode { get; set; }

        public override string ToString()
        {
            return $"Control: {ControlCode}";
        }
    }

    public class ERLiteResultEntry
    {
        [JsonPropertyName("Competitor")]
        public required ERLiteCompetitor Competitor { get; set; }

        [JsonPropertyName("Result")]
        public required ERLiteResultDetail Result { get; set; }

        public override string ToString()
        {
            return $"{Competitor}\n{Result}";
        }
    }

    public class ERLiteCompetitor
    {
        [JsonPropertyName("Name")]
        public required string Name { get; set; }

        [JsonPropertyName("Club")]
        public string Club { get; set; } = "";

        [JsonPropertyName("Card")]
        public int Card { get; set; }

        // funny format (PT1H15M) but value is not actually used other than to indicate presence of start time
        [JsonPropertyName("StartTime")]
        private string? StartTime { get; set; }

        public bool NoNameInResults { get; set; } = false;

        public bool HasStartTime => !string.IsNullOrEmpty(StartTime);


        public override string ToString()
        {
            return $"Competitor: {Name}, Club: {Club}, Card: {Card}";
        }
    }

    public class ERLiteResultDetail
    {
        [JsonPropertyName("CardReadTime")]
        public required string CardReadTimeRaw { get; set; }

        [JsonPropertyName("Time")]
        public long Time { get; set; }

        [JsonPropertyName("Status")]
        public int Status { get; set; }

        [JsonPropertyName("Updated")]
        public long Updated { get; set; }

        [JsonPropertyName("Punches")]
        public required List<ERLitePunch> Punches { get; set; }

        public override string ToString()
        {
            var punchesStr = Punches != null && Punches.Count > 0
                ? string.Join(", ", Punches.Select(p => p.ToString()))
                : "No Punches";
            return $"CardReadTime: {CardReadTimeRaw}, Punches: [{punchesStr}]";
        }


    }

    public class ERLitePunch
    {
        [JsonPropertyName("PunchCode")]
        public required string PunchCode { get; set; }

        [JsonPropertyName("Time")]
        public long Time { get; set; }

        public override string ToString()
        {
            return $"({PunchCode}, {Time})";
        }
    }
}