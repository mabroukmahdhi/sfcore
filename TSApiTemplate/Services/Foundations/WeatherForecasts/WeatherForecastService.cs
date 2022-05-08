// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using System.Linq;
using System.Threading.Tasks;
using TSApiTemplate.Borkers.DateTimes;
using TSApiTemplate.Borkers.Loggings;
using TSApiTemplate.Borkers.Storages;
using TSApiTemplate.Models.WeatherForecasts;

namespace TSApiTemplate.Services.Foundations.WeatherForecasts
{
    public partial class WeatherForecastService : IWeatherForecastService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public WeatherForecastService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }


        public ValueTask<WeatherForecast> AddWeatherForecastAsync(WeatherForecast WeatherForecast) =>
     TryCatch(async () =>
     {
         ValidateWeatherForecastOnAdd(WeatherForecast);

         return await this.storageBroker.InsertWeatherForecastAsync(WeatherForecast);
     });

        public ValueTask<WeatherForecast> RetrieveWeatherForecastByIdAsync(Guid WeatherForecastId) =>
        TryCatch(async () =>
        {
            ValidateWeatherForecastId(WeatherForecastId);

            WeatherForecast maybeWeatherForecast = await this.storageBroker
                .SelectWeatherForecastByIdAsync(WeatherForecastId);

            ValidateStorageWeatherForecast(maybeWeatherForecast, WeatherForecastId);

            return maybeWeatherForecast;
        });

        public IQueryable<WeatherForecast> RetrieveAllWeatherForecasts() =>
        TryCatch(() => this.storageBroker.SelectAllWeatherForecasts());

        public ValueTask<WeatherForecast> ModifyWeatherForecastAsync(WeatherForecast WeatherForecast) =>
        TryCatch(async () =>
        {
            ValidateWeatherForecastOnModify(WeatherForecast);

            WeatherForecast maybeWeatherForecast =
                await this.storageBroker.SelectWeatherForecastByIdAsync(WeatherForecast.Id);

            ValidateStorageWeatherForecast(maybeWeatherForecast, WeatherForecast.Id);
            ValidateAginstStorageWeatherForecastOnModify(inputWeatherForecast: WeatherForecast, storageWeatherForecast: maybeWeatherForecast);

            return await this.storageBroker.UpdateWeatherForecastAsync(WeatherForecast);
        });

        public ValueTask<WeatherForecast> RemoveWeatherForecastByIdAsync(Guid WeatherForecastId) =>
            TryCatch(async () =>
            {
                ValidateWeatherForecastId(WeatherForecastId);

                WeatherForecast maybeWeatherForecast = await this.storageBroker
                    .SelectWeatherForecastByIdAsync(WeatherForecastId);

                ValidateStorageWeatherForecast(maybeWeatherForecast, WeatherForecastId);

                return await this.storageBroker
                    .DeleteWeatherForecastAsync(maybeWeatherForecast);
            });
    }
}
