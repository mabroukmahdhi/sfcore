// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using System.Linq;
using System.Threading.Tasks;
using TSApiTemplate.Models.WeatherForecasts;

namespace TSApiTemplate.Services.Foundations.WeatherForecasts
{
    public interface IWeatherForecastService
    {
        ValueTask<WeatherForecast> AddWeatherForecastAsync(WeatherForecast WeatherForecast);
        ValueTask<WeatherForecast> RetrieveWeatherForecastByIdAsync(Guid WeatherForecastId);
        IQueryable<WeatherForecast> RetrieveAllWeatherForecasts();
        ValueTask<WeatherForecast> ModifyWeatherForecastAsync(WeatherForecast WeatherForecast);
        ValueTask<WeatherForecast> RemoveWeatherForecastByIdAsync(Guid postId);
    }
}
