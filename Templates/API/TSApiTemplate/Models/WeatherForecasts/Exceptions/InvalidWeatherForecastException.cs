// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using Xeptions;

namespace TSApiTemplate.Models.WeatherForecasts.Exceptions
{
    public class InvalidWeatherForecastException : Xeption
    {
        public InvalidWeatherForecastException()
            : base(message: "Invalid WeatherForecast. Please correct the errors and try again.")
        { }
    }
}
