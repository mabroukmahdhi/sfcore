using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TSApiTemplate.Borkers.DateTimes;
using TSApiTemplate.Borkers.Loggings;
using TSApiTemplate.Borkers.Storages;
using TSApiTemplate.Services.Foundations.WeatherForecasts;

namespace TSApiTemplate.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddStorageDbContext(this IServiceCollection services)
        {
            services.AddDbContext<StorageBroker>();
        }

        public static void AddBrokers(this IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ILogger, Logger<LoggingBroker>>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
            services.AddTransient<IDateTimeBroker, DateTimeBroker>();
        }

        public static void AddFoundationServices(this IServiceCollection services)
        {
            services.AddTransient<IWeatherForecastService, WeatherForecastService>();
        }

        public static void AddProcessingServices(this IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        public static void AddOrchestrationServices(this IServiceCollection services)
        {
            throw new NotImplementedException();
        }
    }
}
