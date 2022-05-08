// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace TSApiTemplate.Models.WeatherForecasts.Exceptions
{
    public class AlreadyExistsWeatherForecastException : Xeption
    {
        public AlreadyExistsWeatherForecastException(Exception innerException)
            : base(message: "WeatherForecast with the same id already exists.", innerException)
        { }
    }
}
