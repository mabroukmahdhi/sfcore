// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace TSApiTemplate.Models.WeatherForecasts.Exceptions
{
    public class WeatherForecastServiceException : Xeption
    {
        public WeatherForecastServiceException(Exception innerException)
            : base(message: "WeatherForecast service error occurred, contact support.", innerException) { }
    }
}
