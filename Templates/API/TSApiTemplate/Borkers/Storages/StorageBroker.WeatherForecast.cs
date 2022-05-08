// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;
using TSApiTemplate.Models.WeatherForecasts;

namespace TSApiTemplate.Borkers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public async ValueTask<WeatherForecast> InsertWeatherForecastAsync(WeatherForecast WeatherForecast)
        {
            using var broker =
                new StorageBroker(this.configuration);

            EntityEntry<WeatherForecast> WeatherForecastEntityEntry =
                await broker.WeatherForecasts.AddAsync(WeatherForecast);

            await broker.SaveChangesAsync();

            return WeatherForecastEntityEntry.Entity;
        }

        public IQueryable<WeatherForecast> SelectAllWeatherForecasts()
        {
            using var broker =
                new StorageBroker(this.configuration);

            return broker.WeatherForecasts;
        }

        public async ValueTask<WeatherForecast> SelectWeatherForecastByIdAsync(Guid WeatherForecastId)
        {
            using var broker =
                new StorageBroker(this.configuration);

            return await broker.WeatherForecasts.FindAsync(WeatherForecastId);
        }

        public async ValueTask<WeatherForecast> UpdateWeatherForecastAsync(WeatherForecast WeatherForecast)
        {
            using var broker =
                new StorageBroker(this.configuration);

            EntityEntry<WeatherForecast> WeatherForecastEntityEntry =
                broker.WeatherForecasts.Update(WeatherForecast);

            await broker.SaveChangesAsync();

            return WeatherForecastEntityEntry.Entity;
        }

        public async ValueTask<WeatherForecast> DeleteWeatherForecastAsync(WeatherForecast WeatherForecast)
        {
            using var broker =
                new StorageBroker(this.configuration);

            EntityEntry<WeatherForecast> WeatherForecastEntityEntry =
                broker.WeatherForecasts.Remove(WeatherForecast);

            await broker.SaveChangesAsync();

            return WeatherForecastEntityEntry.Entity;
        }
    }
}
