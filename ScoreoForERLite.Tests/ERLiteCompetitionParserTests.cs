using FluentAssertions;
using ScoreoForERLite.Lib;

namespace ScoreoForERLite.Tests
{
    [TestClass]
    [DeploymentItem(@"test-data\Tsika20.json", "test-data")]
    public sealed class ERLiteCompetitionParserTests
    {
        [TestMethod]

        public void TestELiteCompetitionJsonParsing()
        {
            var stream = File.ReadAllText(@"test-data\Tsika20.json");
            Console.WriteLine(stream);
            var jsonData = ERLiteCompetitionUtils.LoadEliteCompetitionJson(stream);
            Console.Write(jsonData);
            jsonData.Should().NotBeNull();
            jsonData.CompetitionData.Should().NotBeNull();
            jsonData.Courses.Should().HaveCount(34);

            jsonData.Courses[0].Results.Should().BeNullOrEmpty();

            jsonData.Courses[1].Results.Should().HaveCount(7);

            jsonData.Courses[1].Results[0].Competitor.Name.Should().Be("Skofelt Pertti");
            jsonData.Courses[1].Results[0].Competitor.Card.Should().Be(239936);
            jsonData.Courses[1].Results[0].Result.CardReadTimeRaw.Should().Be("/Date(1605347994000+0200)/");
            jsonData.Courses[1].Results[0].Result.Punches.Should().HaveCount(8);
            jsonData.Courses[1].Results[0].Result.Punches[0].PunchCode.Should().Be("0");
            jsonData.Courses[1].Results[0].Result.Punches[0].Time.Should().Be(0);
            jsonData.Courses[1].Results[0].Result.Punches[1].PunchCode.Should().Be("33");
            jsonData.Courses[1].Results[0].Result.Punches[1].Time.Should().Be(737);
        }

        [TestMethod]
        public void TestRogaResults()
        {
            var stream = File.ReadAllText(@"test-data\Tsika20.json");
            var jsonData = ERLiteCompetitionUtils.LoadEliteCompetitionJson(stream);

            var resultFunc = ScoringFunctions.CodeIsResultFunc;
            var codesToPoints = ScoringFunctions.GetControlsToPoints( "31, 32, 33, 34, 35, 38, 39, 41, 43, 46, 47, 51, 52, 53, 56, 57, 62, 65, 67, 73, 75", resultFunc);
            var maxTimeSeconds = 3600;
            var penaltyIntervalSeconds = 60;
            var penaltyAmount = 10;

            var allResults = ERLiteCompetitionUtils.FlatResults(jsonData);

            var rogaResult = ERLiteCompetitionUtils.ToScoreoResult(
                allResults[0],
                new ScoreoResultOptions
                {
                    ControlsToPoints = codesToPoints,
                    MaxTimeSeconds = maxTimeSeconds,
                    PenaltyIntervalSeconds = penaltyIntervalSeconds,
                    PenaltyAmount = penaltyAmount
                });

            rogaResult.Penalty.Should().Be(0);
            rogaResult.Name.Should().Be("Skofelt Pertti");
            rogaResult.Emit.Should().Be("239936");
            rogaResult.Points.Should().Be(168);
            rogaResult.EndTime.Should().Be(3408); 
            rogaResult.Total.Should().Be(168);

            var rogaResult2 = ERLiteCompetitionUtils.ToScoreoResult(
                allResults[6],
                new ScoreoResultOptions
                {
                    
                    ControlsToPoints = codesToPoints,
                    MaxTimeSeconds = maxTimeSeconds,
                    PenaltyIntervalSeconds = penaltyIntervalSeconds,
                    PenaltyAmount = penaltyAmount
                });

            rogaResult2.Penalty.Should().Be(-10);
            rogaResult2.Name.Should().Be("Saarinen Samuli");
            rogaResult2.Emit.Should().Be("506336");
            rogaResult2.Points.Should().Be(546);
            rogaResult2.EndTime.Should().Be(60L * 60 + 17); 
            rogaResult2.Total.Should().Be(536);
        }
    }
}
