// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using TSApiTemplate.Models.WeatherForecasts;
using TSApiTemplate.Models.WeatherForecasts.Exceptions;

namespace TSApiTemplate.Services.Foundations.WeatherForecasts
{
    public partial class WeatherForecastService
    {
        private void ValidateWeatherForecastOnAdd(WeatherForecast weatherForecast)
        {
            ValidateWeatherForecastIsNotNull(weatherForecast);

            Validate(
                (Rule: IsInvalid(weatherForecast.Id), Parameter: nameof(WeatherForecast.Id)),
                (Rule: IsInvalid(weatherForecast.Date), Parameter: nameof(WeatherForecast.Date)),
                (Rule: IsInvalid(weatherForecast.CreatedDate), Parameter: nameof(WeatherForecast.CreatedDate)),
                (Rule: IsInvalid(weatherForecast.UpdatedDate), Parameter: nameof(WeatherForecast.UpdatedDate)),
                (Rule: IsInvalid(weatherForecast.Summary), Parameter: nameof(WeatherForecast.Summary)),

                (Rule: IsNotSame(
                    firstDate: weatherForecast.UpdatedDate,
                    secondDate: weatherForecast.CreatedDate,
                    secondDateName: nameof(WeatherForecast.CreatedDate)),
                Parameter: nameof(WeatherForecast.UpdatedDate)),

                (Rule: IsNotRecent(weatherForecast.CreatedDate), Parameter: nameof(WeatherForecast.CreatedDate)));
        }

        private void ValidateWeatherForecastOnModify(WeatherForecast weatherForecast)
        {
            ValidateWeatherForecastIsNotNull(weatherForecast);

            Validate(
                (Rule: IsInvalid(weatherForecast.Id), Parameter: nameof(WeatherForecast.Id)),
                (Rule: IsInvalid(weatherForecast.Date), Parameter: nameof(WeatherForecast.Date)),
                (Rule: IsInvalid(weatherForecast.CreatedDate), Parameter: nameof(WeatherForecast.CreatedDate)),
                (Rule: IsInvalid(weatherForecast.UpdatedDate), Parameter: nameof(WeatherForecast.UpdatedDate)),
                (Rule: IsInvalid(weatherForecast.Summary), Parameter: nameof(WeatherForecast.Summary)),

                (Rule: IsSame(
                    firstDate: weatherForecast.UpdatedDate,
                    secondDate: weatherForecast.CreatedDate,
                    secondDateName: nameof(WeatherForecast.CreatedDate)),
                Parameter: nameof(WeatherForecast.UpdatedDate)),

                (Rule: IsNotRecent(weatherForecast.UpdatedDate), Parameter: nameof(weatherForecast.UpdatedDate)));
        }

        public void ValidateWeatherForecastId(Guid weatherForecastId) =>
            Validate((Rule: IsInvalid(weatherForecastId), Parameter: nameof(WeatherForecast.Id)));

        private static void ValidateStorageWeatherForecast(WeatherForecast maybeWeatherForecast, Guid weatherForecastId)
        {
            if (maybeWeatherForecast is null)
            {
                throw new NotFoundWeatherForecastException(weatherForecastId);
            }
        }

        private static void ValidateWeatherForecastIsNotNull(WeatherForecast weatherForecast)
        {
            if (weatherForecast is null)
            {
                throw new NullWeatherForecastException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsNotSame(
            DateTimeOffset firstDate,
            DateTimeOffset secondDate,
            string secondDateName) => new
            {
                Condition = firstDate != secondDate,
                Message = $"Date is not the same as {secondDateName}"
            };

        private static dynamic IsSame(
            DateTimeOffset firstDate,
            DateTimeOffset secondDate,
            string secondDateName) => new
            {
                Condition = firstDate == secondDate,
                Message = $"Date is the same as {secondDateName}"
            };

        private dynamic IsNotRecent(DateTimeOffset date) => new
        {
            Condition = IsDateNotRecent(date),
            Message = "Date is not recent"
        };

        private bool IsDateNotRecent(DateTimeOffset date)
        {
            DateTimeOffset currentDateTime =
                this.dateTimeBroker.GetCurrentDateTimeOffset();

            TimeSpan timeDifference = currentDateTime.Subtract(date);
            TimeSpan oneMinute = TimeSpan.FromMinutes(1);

            return timeDifference.Duration() > oneMinute;
        }

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static void ValidateAginstStorageWeatherForecastOnModify(WeatherForecast inputWeatherForecast, WeatherForecast storageWeatherForecast)
        {
            Validate(
                (Rule: IsNotSame(
                    firstDate: inputWeatherForecast.CreatedDate,
                    secondDate: storageWeatherForecast.CreatedDate,
                    secondDateName: nameof(WeatherForecast.CreatedDate)),
                Parameter: nameof(WeatherForecast.CreatedDate)),

                (Rule: IsSame(
                    firstDate: inputWeatherForecast.UpdatedDate,
                    secondDate: storageWeatherForecast.UpdatedDate,
                    secondDateName: nameof(WeatherForecast.UpdatedDate)),
                Parameter: nameof(WeatherForecast.UpdatedDate)));
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidWeatherForecastException = new InvalidWeatherForecastException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidWeatherForecastException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidWeatherForecastException.ThrowIfContainsErrors();
        }
    }
}
