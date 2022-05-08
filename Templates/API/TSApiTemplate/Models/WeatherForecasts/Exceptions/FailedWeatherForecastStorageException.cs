// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace TSApiTemplate.Models.WeatherForecasts.Exceptions
{
    public class FailedWeatherForecastStorageException : Xeption
    {
        public FailedWeatherForecastStorageException(Exception innerException)
            : base(message: "Failed WeatherForecast storage error occurred, contact support.", innerException)
        { }
    }
}
