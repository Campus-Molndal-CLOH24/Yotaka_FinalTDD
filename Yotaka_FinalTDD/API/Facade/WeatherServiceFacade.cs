using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Yotaka_FinalTDD.API.Interfaces;

namespace Yotaka_FinalTDD.API.Facade
{
    public class WeatherServiceFacade
    {
        private readonly IWeatherService _weatherService;
        public WeatherServiceFacade(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public async Task<string> GetWeather(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentException("City cannot be null or empty", nameof(city));
            }
            try
            {
                return await _weatherService.GetCurrentWeatherAsync(city);
            }
            catch (HttpRequestException ex)
            {
                return $"Failed to fetch weather data: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";

            }
        }
    }
}
