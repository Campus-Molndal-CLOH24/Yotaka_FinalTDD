using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yotaka_FinalTDD.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.API.Tests
{
    [TestClass()]
    public class WeatherClientTests
    {
        private WeatherClient _weatherClient;
        [TestInitialize]
        public void Setup() 
        {
            _weatherClient = new WeatherClient(new HttpClient());
        }
        
        //method GetCurrentWeatherAsync should return correct weather for a valid city (Malmö).
        [TestMethod()]
        public async Task GetCurrentWeatherAsync_ShouldReturnWeather_ForValidCity()
        {
            //arrange
            var city = "Malmö";
            //act
            var result = await _weatherClient.GetCurrentWeatherAsync(city);
            //assert
            Assert.AreEqual("Raining", result, "Weather for Malmö should be raining ");
        }

        //It should return "City not found" for an invalid city (Lund).
        [TestMethod()]
        public async Task GetCurrentWeatherAsync_ShouldReturnCityNotFound_ForInvalidCity()
        {
            //arrange
            var city = "Lund";
            //act
            var result = await _weatherClient.GetCurrentWeatherAsync(city);
            //assert
            Assert.AreEqual("City not found", result, "City Lund should not be found");
        }

        //it should return correct weather for another valid city (Stockholm).
        [TestMethod()]
        public async Task GetCurrentWeatherAsync_ShouldReturnWeather_ForAnotherValidCity()
        {
            //arrange
            var city = "Stockholm";
            //act
            var result = await _weatherClient.GetCurrentWeatherAsync(city);
            //assert
            Assert.AreEqual("Sunny", result, "Weather for Stockholm should be sunny ");
        }

        //It should throw an ArgumentException for a null  and empty city.
        [TestMethod()]
        public async Task GetCurrentWeatherAsync_ShouldThrowArgumentException_ForNullCity()
        {
            //arrange
            string city = null;
            //act
            async Task Act() => await _weatherClient.GetCurrentWeatherAsync(city);
            //assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(Act);
        }
        
        //It should return correct weather for a city with different letters (gothenburg) case sensetive.
        [TestMethod()]
        public async Task GetCurrentWeatherAsync_ShouldReturnWeather_ForCityWithDifferentLetters()
        {
            //arrange
            var city = "gothenburg";
            //act
            var result = await _weatherClient.GetCurrentWeatherAsync(city);
            //assert
            Assert.AreEqual("Cloudy", result, "Weather for gothenburg should be cloudy ");
        }


        //It should return "City not found" for a city with special characters (M@lmö!).
        [TestMethod()]
        public async Task GetCurrentWeatherAsync_ShouldReturnCityNotFound_ForCityWithSpecialCharacters()
        {
            //arrange
            var city = "M@lmö!";
            //act
            var result = await _weatherClient.GetCurrentWeatherAsync(city);
            //assert
            Assert.AreEqual("City not found", result, "City M@lmö! should not be found");
        }

    }
}