// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace TSApiTemplate.Models.WeatherForecasts.Exceptions
{
    public class WeatherForecastDependencyException : Xeption
    {
        public WeatherForecastDependencyException(Exception innerException) :
            base(message: "WeatherForecast dependency error occurred, contact support.", innerException)
        { }
    }
}
