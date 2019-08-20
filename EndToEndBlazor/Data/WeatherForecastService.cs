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

        public Task<WeatherForecast> createForescastAsync(WeatherForecast objWeatherForecast)
        {
            using (var context = new EndtoendblazorContext())
            {
                context.WeatherForecast.Add(objWeatherForecast);
                context.SaveChanges();
            }

            return Task.FromResult(objWeatherForecast);
        }

        public Task<bool> UpdateForescastAsync(WeatherForecast weatherForecast)
        {
            using (var context = new EndtoendblazorContext())
            {
                var existingWeatherforescast = context.WeatherForecast.Where(f => f.Id.Equals(weatherForecast.Id)).FirstOrDefault();

                if (existingWeatherforescast != null)
                {
                    existingWeatherforescast.Date = weatherForecast.Date;
                    existingWeatherforescast.Summary = weatherForecast.Summary;
                    existingWeatherforescast.TemperatureC = weatherForecast.TemperatureC;
                    existingWeatherforescast.TemperatureF = weatherForecast.TemperatureF;

                    context.SaveChanges();
                }
                else
                {
                    return Task.FromResult(false);
                }


                return Task.FromResult(true);

            }

           
        }

        public Task<bool> DeleteForescastAsync(int id)
        {
            using (var context = new EndtoendblazorContext())
            {
                var deleteForescast = context.WeatherForecast.Where(w => w.Id.Equals(id)).FirstOrDefault();

                if (deleteForescast != null)
                {
                    context.WeatherForecast.Remove(deleteForescast);

                    context.SaveChanges();
                }
                else
                {
                    return Task.FromResult(false);
                }
            }

            return Task.FromResult(true);
        }

    }

}
