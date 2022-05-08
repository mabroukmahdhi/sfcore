// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using Xeptions;

namespace TSApiTemplate.Models.WeatherForecasts.Exceptions
{
    public class NullWeatherForecastException : Xeption
    {
        public NullWeatherForecastException()
            : base(message: "WeatherForecast is null.")
        { }
    }
}
