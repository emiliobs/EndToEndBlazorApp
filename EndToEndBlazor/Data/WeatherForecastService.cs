using EndToEndBlazorDB.Data.EndToEndaBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndToEndBlazor.Data
{
    public class WeatherForecastService
    {
        public Task<List<WeatherForecast>> GetForecastAsync(string strCurrentUser)
        {
            List<WeatherForecast> colWeaterForescast = new List<WeatherForecast>();
            //Get Waeter Forescasts
            using (var context = new EndtoendblazorContext())
            {
                colWeaterForescast = (from WeatherForecast in context.WeatherForecast
                                      //Only get entris for the current logged in user
                                      where WeatherForecast.UserName.Equals(strCurrentUser)
                                      select WeatherForecast).ToList();
            }


            return Task.FromResult(colWeaterForescast);

        }

    }
}
