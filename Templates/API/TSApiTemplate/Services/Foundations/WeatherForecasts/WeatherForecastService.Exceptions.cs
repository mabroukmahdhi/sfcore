// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TSApiTemplate.Models.WeatherForecasts;
using TSApiTemplate.Models.WeatherForecasts.Exceptions;
using Xeptions;

namespace TSApiTemplate.Services.Foundations.WeatherForecasts
{
    public partial class WeatherForecastService
    {
        private delegate ValueTask<WeatherForecast> ReturningWeatherForecastFunction();
        private delegate IQueryable<WeatherForecast> ReturningWeatherForecastsFunction();

        private async ValueTask<WeatherForecast> TryCatch(ReturningWeatherForecastFunction returningWeatherForecastFunction)
        {
            try
            {
                return await returningWeatherForecastFunction();
            }
            catch (NullWeatherForecastException nullWeatherForecastException)
            {
                throw CreateAndLogValidationException(nullWeatherForecastException);
            }
            catch (InvalidWeatherForecastException invalidWeatherForecastException)
            {
                throw CreateAndLogValidationException(invalidWeatherForecastException);
            }
            catch (SqlException sqlException)
            {
                var failedWeatherForecastStorageException =
                    new FailedWeatherForecastStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedWeatherForecastStorageException);
            }
            catch (NotFoundWeatherForecastException notFoundWeatherForecastException)
            {
                throw CreateAndLogValidationException(notFoundWeatherForecastException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsWeatherForecastException =
                    new AlreadyExistsWeatherForecastException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistsWeatherForecastException);
            }
            catch (ForeignKeyConstraintConflictException foreignKeyConstraintConflictException)
            {
                var invalidWeatherForecastReferenceException =
                    new InvalidWeatherForecastReferenceException(foreignKeyConstraintConflictException);

                throw CreateAndLogDependencyValidationException(invalidWeatherForecastReferenceException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedWeatherForecastException = new LockedWeatherForecastException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyValidationException(lockedWeatherForecastException);
            }
            catch (DbUpdateException databaseUpdateException)
            {
                var failedWeatherForecastStorageException =
                    new FailedWeatherForecastStorageException(databaseUpdateException);

                throw CreateAndLogDependecyException(failedWeatherForecastStorageException);
            }
            catch (Exception exception)
            {
                var failedWeatherForecastServiceException =
                    new FailedWeatherForecastServiceException(exception);

                throw CreateAndLogServiceException(failedWeatherForecastServiceException);
            }
        }

        private IQueryable<WeatherForecast> TryCatch(ReturningWeatherForecastsFunction returningWeatherForecastsFunction)
        {
            try
            {
                return returningWeatherForecastsFunction();
            }
            catch (SqlException sqlException)
            {
                var failedWeatherForecastStorageException =
                    new FailedWeatherForecastStorageException(sqlException);
                throw CreateAndLogCriticalDependencyException(failedWeatherForecastStorageException);
            }
            catch (Exception exception)
            {
                throw CreateAndLogServiceException(exception);
            }
        }

        private WeatherForecastValidationException CreateAndLogValidationException(
            Xeption exception)
        {
            var weatherForecastValidationException =
                new WeatherForecastValidationException(exception);

            this.loggingBroker.LogError(weatherForecastValidationException);

            return weatherForecastValidationException;
        }

        private WeatherForecastDependencyException CreateAndLogCriticalDependencyException(
            Xeption exception)
        {
            var weatherForecastDependencyException = new WeatherForecastDependencyException(exception);
            this.loggingBroker.LogCritical(weatherForecastDependencyException);

            return weatherForecastDependencyException;
        }

        private WeatherForecastDependencyValidationException CreateAndLogDependencyValidationException(
        Xeption exception)
        {
            var weatherForecastDependencyValidationException =
                new WeatherForecastDependencyValidationException(exception);

            this.loggingBroker.LogError(weatherForecastDependencyValidationException);

            return weatherForecastDependencyValidationException;
        }

        private WeatherForecastDependencyException CreateAndLogDependecyException(
            Xeption exception)
        {
            var weatherForecastDependencyException = new WeatherForecastDependencyException(exception);
            this.loggingBroker.LogError(weatherForecastDependencyException);

            return weatherForecastDependencyException;
        }

        private WeatherForecastServiceException CreateAndLogServiceException(
            Xeption exception)
        {
            var weatherForecastServiceException = new WeatherForecastServiceException(exception);
            this.loggingBroker.LogError(weatherForecastServiceException);

            return weatherForecastServiceException;
        }

        private WeatherForecastServiceException CreateAndLogServiceException(
            Exception exception)
        {
            var weatherForecastServiceException = new WeatherForecastServiceException(exception);
            this.loggingBroker.LogError(weatherForecastServiceException);

            return weatherForecastServiceException;
        }
    }
}
