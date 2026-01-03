using WeatherService.Core.Entities;

namespace WeatherService.Core.Interfaces;

public interface IWeatherService
{
    IEnumerable<WeatherForecast> GetForecasts();
}
