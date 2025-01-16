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
            // Simulate API call
            return Task.FromResult("Raining");
        }
    }
}
