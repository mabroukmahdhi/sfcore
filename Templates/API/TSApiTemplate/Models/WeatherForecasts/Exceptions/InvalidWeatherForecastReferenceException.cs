// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace TSApiTemplate.Models.WeatherForecasts.Exceptions
{
    public class InvalidWeatherForecastReferenceException : Xeption
    {
        public InvalidWeatherForecastReferenceException(Exception innerException)
            : base(message: "Invalid WeatherForecast reference error occurred.", innerException) { }
    }
}