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
        public string GetWeather(string city)
        {
            var weatherTask = _weatherService.GetCurrentWeatherAsync(city);
            weatherTask.Wait();
            return weatherTask.Result;
        }
    }
}
