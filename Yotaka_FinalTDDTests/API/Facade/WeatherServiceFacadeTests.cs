﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yotaka_FinalTDD.API.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yotaka_FinalTDD.API.Interfaces;
using NSubstitute;

namespace Yotaka_FinalTDD.API.Facade.Tests
{
    [TestClass()]
    public class WeatherServiceFacadeTests
    {
        [TestMethod()]
        public async Task GetWeather_returnCorrectWeather()
        {
            //arrange
            var mockWeatherService = Substitute.For<IWeatherService>();
            //expected where GetCurrentWeatherAsync is called with "GBG" as argument, return "Sunny"
            mockWeatherService.GetCurrentWeatherAsync("GBG").Returns(Task.FromResult("Sunny"));
            mockWeatherService.GetCurrentWeatherAsync("Bangkok").Returns(Task.FromResult("Warm like staying in Hell!"));
            var weatherServiceFacade = new WeatherServiceFacade(mockWeatherService);
            //act
            var result = weatherServiceFacade.GetWeather("GBG");
            var result1 = weatherServiceFacade.GetWeather("Bangkok");
            //assert
            Assert.AreEqual("Sunny", result);
            await mockWeatherService.Received().GetCurrentWeatherAsync("GBG");
            Assert.AreEqual("Warm like staying in Hell!", result1);
            await mockWeatherService.Received().GetCurrentWeatherAsync("Bangkok");
        }
        //throw exception when city is null
        [TestMethod()]
        public async Task GetWeather_throwExceptionWhenCityIsNull()
        {
            //arrange
            var mockWeatherService = Substitute.For<IWeatherService>();
            var weatherServiceFacade = new WeatherServiceFacade(mockWeatherService);
            
            //act and assert
            Assert.ThrowsException<ArgumentException>(() => weatherServiceFacade.GetWeather(null));
        }
        //throw exception when city is empty
        [TestMethod()]
        public async Task GetWeather_throwExceptionWhenCityIsEmpty()
        {
            //arrange
            var mockWeatherService = Substitute.For<IWeatherService>();
            var weatherServiceFacade = new WeatherServiceFacade(mockWeatherService);

            //act and assert
            Assert.ThrowsException<ArgumentException>(() => weatherServiceFacade.GetWeather(""));
        }
        //handle invalid city name
        [TestMethod()]
        public async Task GetWeather_handleInvalidCityName()
        {
            //arrange
            var mockWeatherService = Substitute.For<IWeatherService>();
            mockWeatherService.GetCurrentWeatherAsync("Invalidcity").Returns(Task.FromResult("unknow"));
            var weatherServiceFacade = new WeatherServiceFacade(mockWeatherService);
            //act 
            var result = weatherServiceFacade.GetWeather("Invalidcity");
            //assert
            Assert.AreEqual("unknow", result, "Faile testing");
            await mockWeatherService.Received().GetCurrentWeatherAsync("Invalidcity");
        }

    }
}