using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MP.Blazor.Demo.Core.Application.Contracts;
using MP.Blazor.Demo.Core.Domain.Entities;

namespace MP.Blazor.Demo.Pages
{
    public partial class FetchData
    {
        [Inject]
        private IWeatherForecastService WeatherForecastService { get; set; }

        private WeatherForecast[] forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await WeatherForecastService.GetForecastAsync(DateTime.Now)
                .ConfigureAwait(false);
        }
    }
}