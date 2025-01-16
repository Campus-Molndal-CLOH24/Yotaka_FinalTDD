using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yotaka_FinalTDD.API.Interfaces
{
    public interface IWeatherService 
    {
        Task<string> GetCurrentWeatherAsync(string city);
    }
}
