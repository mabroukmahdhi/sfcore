// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using Xeptions;

namespace TSApiTemplate.Models.WeatherForecasts.Exceptions
{
    public class WeatherForecastDependencyValidationException : Xeption
    {
        public WeatherForecastDependencyValidationException(Xeption innerException)
            : base(message: "WeatherForecast dependency validation occurred, please try again.", innerException)
        { }
    }
}
