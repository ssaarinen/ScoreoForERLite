using FluentAssertions;
using ScoreoForERLite.Lib;

namespace ScoreoForERLite.Tests
{
    [TestClass]
    public class ScoringFunctionsTests
    {
        [TestMethod]
        public void GetControlsToPoints_ShouldParseCodesAndPointsCorrectly()
        {
            // Arrange
            string input = "31:10,32:5,33,34:7,33:15";
            // 33 appears twice, should be distinct by code
            var scoringFunc = ScoringFunctions.CodeIsResultFunc;

            // Act
            var result = ScoringFunctions.GetControlsToPoints(input, scoringFunc);

            // Assert
            result.Should().HaveCount(4);
            result[31].Should().Be(10);
            result[32].Should().Be(5);
            result[33].Should().Be(33); // uses scoringFunc for missing points
            result[34].Should().Be(7);
        }

        [TestMethod]
        public void GetControlsToPoints_ShouldHandleEmptyAndWhitespaceEntries()
        {
            // Arrange
            string input = " , , 35 : 8,, 36  ";
            var scoringFunc = ScoringFunctions.CodeIsResultFunc;

            // Act
            var result = ScoringFunctions.GetControlsToPoints(input, scoringFunc);

            // Assert
            result.Should().HaveCount(2);
            result[35].Should().Be(8);
            result[36].Should().Be(36);
        }

        [TestMethod]
        public void GetControlsToPoints_ShouldReturnEmptyDictionaryForInvalidInput()
        {
            // Arrange
            string input = "foo,bar:baz";
            var scoringFunc = ScoringFunctions.CodeIsResultFunc;

            // Act
            var result = ScoringFunctions.GetControlsToPoints(input, scoringFunc);

            // Assert
            result.Should().BeEmpty();
        }

        //add unit tests for all other scoring functions
        [TestMethod]
        public void FirstNumberIsResultFunc_ShouldReturnCorrectPoints()
        {
            ScoringFunctions.FirstNumberIsResultFunc(38).Should().Be(3);
            ScoringFunctions.FirstNumberIsResultFunc(45).Should().Be(4);
            ScoringFunctions.FirstNumberIsResultFunc(89).Should().Be(8);
            ScoringFunctions.FirstNumberIsResultFunc(131).Should().Be(13);
            
        }

        [TestMethod]
        public void FirstNumberIsResultWith10PointCapFunc_ShouldReturnCorrectPoints()
        {
            ScoringFunctions.FirstNumberIsResultWith10PointCapFunc(89).Should().Be(8);
            ScoringFunctions.FirstNumberIsResultWith10PointCapFunc(131).Should().Be(10);

        }

        [TestMethod]
        public void CodeIsResultFunc_ShouldReturnCorrectPoints()
        {
            ScoringFunctions.CodeIsResultFunc(89).Should().Be(89);
            ScoringFunctions.CodeIsResultFunc(131).Should().Be(131);

        }

    }
}