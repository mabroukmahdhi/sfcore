// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace TSApiTemplate.Models.WeatherForecasts.Exceptions
{
    public class NotFoundWeatherForecastException : Xeption
    {
        public NotFoundWeatherForecastException(Guid commentId)
            : base(message: $"Couldn't find WeatherForecast with id: {commentId}.")
        { }
    }
}
