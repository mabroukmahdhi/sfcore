// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace TSApiTemplate.Models.WeatherForecasts.Exceptions
{
    public class LockedWeatherForecastException : Xeption
    {
        public LockedWeatherForecastException(Exception innerException)
            : base(message: "Locked WeatherForecast record exception, please try again later", innerException) { }
    }
}
