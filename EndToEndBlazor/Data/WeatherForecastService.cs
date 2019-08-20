using EndToEndBlazorDB.Data;
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
                colWeaterForescast = (from weatherForecast in context.WeatherForecast

                                          // only get entries for the current logged in user

                                      where weatherForecast.UserName == strCurrentUser

                                      select weatherForecast).ToList();

            }


            return Task.FromResult(colWeaterForescast);

        }

    }
}
