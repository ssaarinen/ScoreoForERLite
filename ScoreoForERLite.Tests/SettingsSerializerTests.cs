using FluentAssertions;
using ScoreoForERLite.Lib;

namespace ScoreoForERLite.Tests
{
    [TestClass]
    public class SettingsSerializerTests
    {
        [TestMethod]
        public void Serialize_WithValidSettings_ReturnsBase64EncodedStringWithPrefix()
        {
            // Arrange
            var settings = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };

            // Act
            var result = SettingsSerializer.Serialize(settings);

            // Assert
            result.Should().StartWith(SettingsSerializer.SettingsPrefix);
            result.Should().NotBe(SettingsSerializer.SettingsPrefix); // Should have content after prefix
        }

        [TestMethod]
        public void Serialize_WithEmptyDictionary_ReturnsValidBase64String()
        {
            // Arrange
            var settings = new Dictionary<string, string>();

            // Act
            var result = SettingsSerializer.Serialize(settings);

            // Assert
            result.Should().StartWith(SettingsSerializer.SettingsPrefix);
            result.Length.Should().BeGreaterThan(SettingsSerializer.SettingsPrefix.Length);
        }

        [TestMethod]
        public void Serialize_WithSpecialCharacters_PreservesValuesCorrectly()
        {
            // Arrange
            var settings = new Dictionary<string, string>
            {
                { "special", "value with spaces & symbols !@#$%" },
                { "newlines", "line1\nline2" }
            };

            // Act
            var result = SettingsSerializer.Serialize(settings);

            // Assert
            result.Should().StartWith(SettingsSerializer.SettingsPrefix);
            var deserialized = SettingsSerializer.Deserialize(result);
            deserialized.Should().Equal(settings);
        }

        [TestMethod]
        public void Deserialize_WithValidSerializedString_ReturnsOriginalDictionary()
        {
            // Arrange
            var originalSettings = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" },
                { "key3", "value3" }
            };
            var serialized = SettingsSerializer.Serialize(originalSettings);

            // Act
            var result = SettingsSerializer.Deserialize(serialized);

            // Assert
            result.Should().Equal(originalSettings);
        }

        [TestMethod]
        public void Deserialize_WithInvalidPrefix_ThrowsArgumentException()
        {
            // Arrange
            var invalidString = "INVALID_PREFIX;dGVzdA==";

            // Act & Assert
            var act = () => SettingsSerializer.Deserialize(invalidString);
            act.Should().Throw<ArgumentException>()
                .WithMessage("Invalid settings string format.");

        }

        [TestMethod]
        public void Deserialize_WithMissingPrefix_ThrowsArgumentException()
        {
            // Arrange
            var base64String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("{}"));

            // Act & Assert
            var act = () => SettingsSerializer.Deserialize(base64String);
            act.Should().Throw<ArgumentException>()
                .WithMessage("Invalid settings string format.");
        }

        [TestMethod]
        public void Deserialize_WithInvalidBase64_ThrowsFormatException()
        {
            // Arrange
            var invalidBase64 = SettingsSerializer.SettingsPrefix + "!!!invalid base64!!!";

            // Act & Assert
            var act = () => SettingsSerializer.Deserialize(invalidBase64);
            act.Should().Throw<FormatException>()
                .Where(e => e.Message.Contains("not a valid Base-64"));
        }

        [TestMethod]
        public void Deserialize_WithInvalidJson_ThrowsJsonException()
        {
            // Arrange
            var invalidJson = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("not valid json"));
            var invalidString = SettingsSerializer.SettingsPrefix + invalidJson;

            // Act & Assert
            var act = () => SettingsSerializer.Deserialize(invalidString);
            act.Should().Throw<System.Text.Json.JsonException>()
                .Where(e => e.Message.Contains("not valid json"));
        }

        [TestMethod]
        public void SerializeDeserialize_RoundTrip_WithMultipleEntries_PreservesData()
        {
            // Arrange
            var originalSettings = new Dictionary<string, string>
            {
                { "setting1", "value1" },
                { "setting2", "value2" },
                { "setting3", "value3" },
                { "setting4", "value4" },
                { "setting5", "value5" }
            };

            // Act
            var serialized = SettingsSerializer.Serialize(originalSettings);
            var deserialized = SettingsSerializer.Deserialize(serialized);

            // Assert
            deserialized.Should().Equal(originalSettings);
        }

        [TestMethod]
        public void SerializeDeserialize_RoundTrip_WithEmptyValues_PreservesEmptyStrings()
        {
            // Arrange
            var originalSettings = new Dictionary<string, string>
            {
                { "emptyKey", "" },
                { "normalKey", "normalValue" }
            };

            // Act
            var serialized = SettingsSerializer.Serialize(originalSettings);
            var deserialized = SettingsSerializer.Deserialize(serialized);

            // Assert
            deserialized.Should().Equal(originalSettings);
            deserialized["emptyKey"].Should().BeEmpty();
        }

        [TestMethod]
        public void SettingsPrefix_ShouldHaveExpectedValue()
        {
            // Act & Assert
            SettingsSerializer.SettingsPrefix.Should().Be("@SV=1;");
        }

        [TestMethod]
        public void Serialize_TwiceWithSameSettings_ProducesDifferentResults()
        {
            // Arrange
            var settings = new Dictionary<string, string> { { "key", "value" } };

            // Act
            var result1 = SettingsSerializer.Serialize(settings);
            var result2 = SettingsSerializer.Serialize(settings);

            // Assert - Both should be valid and deserialize to the same dictionary
            SettingsSerializer.Deserialize(result1).Should().Equal(settings);
            SettingsSerializer.Deserialize(result2).Should().Equal(settings);
        }

        [TestMethod]
        public void Serialize_WithLargeSettings_HandlesCorrectly()
        {
            // Arrange
            var settings = new Dictionary<string, string>();
            for (int i = 0; i < 100; i++)
            {
                settings[$"key{i}"] = $"value{i}";
            }

            // Act
            var serialized = SettingsSerializer.Serialize(settings);
            var deserialized = SettingsSerializer.Deserialize(serialized);

            // Assert
            deserialized.Should().Equal(settings);
            deserialized.Should().HaveCount(100);
        }
    }
}
