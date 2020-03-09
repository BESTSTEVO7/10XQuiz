namespace Quiz.WebApp.Test.Data
{
    using FluentAssertions;
    using Quiz.WebApp.Data;
    using Xunit;

    public class WeatherForecastTest
    {
        [Theory]
        [InlineData(0, 32)]
        [InlineData(5, 41)]
        [InlineData(-5, 23)]
        [InlineData(-16, 3)]
        public void ConvertFromCelciusToFahrenheit(int celcius, int fahrenheit)
        {
            // Arrange
            WeatherForecast weatherForecast = new WeatherForecast { TemperatureC = celcius };

            // Act
            int result = weatherForecast.TemperatureF;

            // Assert
            result.Should().Be(fahrenheit);
        }
    }
}
