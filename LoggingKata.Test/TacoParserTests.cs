using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
            // Arrange

            var tacoParser = new TacoParser();

            // Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            // Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638, -84.677017, " Taco Bell Acwort...")]
        public void ShouldParse(string fullString, double latitude, double longitude, string tacoBellName)
        {
            // TODO: Complete Should Parse

            // Arrange
            var should = new TacoParser();
            //Act
            var actual = should.Parse(fullString);
            //Assert
            Assert.Equal(latitude, actual.Location.Latitude);
            Assert.Equal(longitude, actual.Location.Longitude);
            Assert.Equal(tacoBellName, actual.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse

            //Arrange
            var should = new TacoParser();

            //Act
            var actual = should.Parse(str);

            //Assert
            Assert.Null(actual);
        }
    }
}
