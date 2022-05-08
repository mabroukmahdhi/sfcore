// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using Xeptions;

namespace TSApiTemplate.Models.WeatherForecasts.Exceptions
{
    public class WeatherForecastValidationException : Xeption
    {
        public WeatherForecastValidationException(Xeption innerException)
            : base(message: "WeatherForecast validation errors occurred, please try again.",
                  innerException)
        { }
    }
}
