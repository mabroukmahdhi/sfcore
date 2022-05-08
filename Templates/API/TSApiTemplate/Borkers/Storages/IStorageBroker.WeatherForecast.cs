// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using System.Linq;
using System.Threading.Tasks;
using TSApiTemplate.Models.WeatherForecasts;

namespace TSApiTemplate.Borkers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<WeatherForecast> InsertWeatherForecastAsync(WeatherForecast weatherForecast);
        IQueryable<WeatherForecast> SelectAllWeatherForecasts();
        ValueTask<WeatherForecast> SelectWeatherForecastByIdAsync(Guid weatherForecastId);
        ValueTask<WeatherForecast> UpdateWeatherForecastAsync(WeatherForecast weatherForecast);
        ValueTask<WeatherForecast> DeleteWeatherForecastAsync(WeatherForecast weatherForecast);
    }
}
