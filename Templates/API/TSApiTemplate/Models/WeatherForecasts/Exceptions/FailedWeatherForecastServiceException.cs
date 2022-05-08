// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace TSApiTemplate.Models.WeatherForecasts.Exceptions
{
    public class FailedWeatherForecastServiceException : Xeption
    {
        public FailedWeatherForecastServiceException(Exception innerException)
            : base(message: "Failed WeatherForecast service occurred, please contact support", innerException)
        { }
    }
}
