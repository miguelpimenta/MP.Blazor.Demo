using System;
using MP.Blazor.Demo.Core.Domain.Common;

namespace MP.Blazor.Demo.Core.Domain.Entities
{
    public class WeatherForecast : BaseEntity
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}