using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yotaka_FinalTDD.API.Facade;
using Yotaka_FinalTDD.API.Interfaces;
using System.Net.Http;

namespace Yotaka_FinalTDD.API 
{
    public class WeatherClient : IWeatherService
    {
        private readonly HttpClient _httpClient;
        public WeatherClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<string> GetCurrentWeatherAsync(string city)
        {
            var simulateData = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) // case-insensitive. 
            {
                { "Stockholm", "Sunny"},
                { "Gothenburg", "Cloudy"},
                { "Malmö", "Raining"}
            };
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentException("City cannot be null or empty", nameof(city));
            }
            // Simulate API call
            return Task.FromResult(simulateData.ContainsKey(city) ? simulateData[city] : "City not found");
        }
    }
}
