using System;
using System.Collections.Generic;

namespace EndToEndBlazorDB.Data.EndToEndaBlazor
{
    public partial class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? TemperatureC { get; set; }
        public int? TemperatureF { get; set; }
        public string Summary { get; set; }
        public string UserName { get; set; }
    }
}