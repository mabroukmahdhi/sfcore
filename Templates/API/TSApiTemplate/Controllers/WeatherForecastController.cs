// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;
using TSApiTemplate.Models.WeatherForecasts;
using TSApiTemplate.Models.WeatherForecasts.Exceptions;
using TSApiTemplate.Services.Foundations.WeatherForecasts;

namespace TSApiTemplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : RESTFulController
    {
        private readonly IWeatherForecastService weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService) =>
            this.weatherForecastService = weatherForecastService;

        [HttpPost]
        public async ValueTask<ActionResult<WeatherForecast>> PostWeatherForecastAsync(WeatherForecast weatherForecast)
        {
            try
            {
                WeatherForecast addedWeatherForecast =
                    await this.weatherForecastService.AddWeatherForecastAsync(weatherForecast);

                return Created(addedWeatherForecast);
            }
            catch (WeatherForecastValidationException weatherForecastValidationException)
            {
                return BadRequest(weatherForecastValidationException.InnerException);
            }
            catch (WeatherForecastDependencyValidationException weatherForecastValidationException)
                when (weatherForecastValidationException.InnerException is InvalidWeatherForecastReferenceException)
            {
                return FailedDependency(weatherForecastValidationException.InnerException);
            }
            catch (WeatherForecastDependencyValidationException weatherForecastDependencyValidationException)
               when (weatherForecastDependencyValidationException.InnerException is AlreadyExistsWeatherForecastException)
            {
                return Conflict(weatherForecastDependencyValidationException.InnerException);
            }
            catch (WeatherForecastDependencyException weatherForecastDependencyException)
            {
                return InternalServerError(weatherForecastDependencyException);
            }
            catch (WeatherForecastServiceException weatherForecastServiceException)
            {
                return InternalServerError(weatherForecastServiceException);
            }
        }

        [HttpGet]
        public ActionResult<IQueryable<WeatherForecast>> GetAllWeatherForecasts()
        {
            try
            {
                IQueryable<WeatherForecast> retrievedWeatherForecasts =
                    this.weatherForecastService.RetrieveAllWeatherForecasts();

                return Ok(retrievedWeatherForecasts);
            }
            catch (WeatherForecastDependencyException weatherForecastDependencyException)
            {
                return InternalServerError(weatherForecastDependencyException);
            }
            catch (WeatherForecastServiceException weatherForecastServiceException)
            {
                return InternalServerError(weatherForecastServiceException);
            }
        }

        [HttpGet("{weatherForecastId}")]
        public async ValueTask<ActionResult<WeatherForecast>> GetWeatherForecastByIdAsync(Guid weatherForecastId)
        {
            try
            {
                WeatherForecast weatherForecast = await this.weatherForecastService.RetrieveWeatherForecastByIdAsync(weatherForecastId);

                return Ok(weatherForecast);
            }
            catch (WeatherForecastValidationException weatherForecastValidationException)
                when (weatherForecastValidationException.InnerException is NotFoundWeatherForecastException)
            {
                return NotFound(weatherForecastValidationException.InnerException);
            }
            catch (WeatherForecastValidationException weatherForecastValidationException)
            {
                return BadRequest(weatherForecastValidationException.InnerException);
            }
            catch (WeatherForecastDependencyException weatherForecastDependencyException)
            {
                return InternalServerError(weatherForecastDependencyException);
            }
            catch (WeatherForecastServiceException weatherForecastServiceException)
            {
                return InternalServerError(weatherForecastServiceException);
            }
        }

        [HttpPut]
        public async ValueTask<ActionResult<WeatherForecast>> PutWeatherForecastAsync(WeatherForecast weatherForecast)
        {
            try
            {
                WeatherForecast modifiedWeatherForecast =
                    await this.weatherForecastService.ModifyWeatherForecastAsync(weatherForecast);

                return Ok(modifiedWeatherForecast);
            }
            catch (WeatherForecastValidationException weatherForecastValidationException)
                when (weatherForecastValidationException.InnerException is NotFoundWeatherForecastException)
            {
                return NotFound(weatherForecastValidationException.InnerException);
            }
            catch (WeatherForecastValidationException weatherForecastValidationException)
            {
                return BadRequest(weatherForecastValidationException.InnerException);
            }
            catch (WeatherForecastDependencyValidationException weatherForecastValidationException)
                when (weatherForecastValidationException.InnerException is InvalidWeatherForecastReferenceException)
            {
                return FailedDependency(weatherForecastValidationException.InnerException);
            }
            catch (WeatherForecastDependencyValidationException weatherForecastDependencyValidationException)
               when (weatherForecastDependencyValidationException.InnerException is AlreadyExistsWeatherForecastException)
            {
                return Conflict(weatherForecastDependencyValidationException.InnerException);
            }
            catch (WeatherForecastDependencyException weatherForecastDependencyException)
            {
                return InternalServerError(weatherForecastDependencyException);
            }
            catch (WeatherForecastServiceException weatherForecastServiceException)
            {
                return InternalServerError(weatherForecastServiceException);
            }
        }

        [HttpDelete("{weatherForecastId}")]
        public async ValueTask<ActionResult<WeatherForecast>> DeleteWeatherForecastByIdAsync(Guid weatherForecastId)
        {
            try
            {
                WeatherForecast deletedWeatherForecast =
                    await this.weatherForecastService.RemoveWeatherForecastByIdAsync(weatherForecastId);

                return Ok(deletedWeatherForecast);
            }
            catch (WeatherForecastValidationException weatherForecastValidationException)
                when (weatherForecastValidationException.InnerException is NotFoundWeatherForecastException)
            {
                return NotFound(weatherForecastValidationException.InnerException);
            }
            catch (WeatherForecastValidationException weatherForecastValidationException)
            {
                return BadRequest(weatherForecastValidationException.InnerException);
            }
            catch (WeatherForecastDependencyValidationException weatherForecastDependencyValidationException)
                when (weatherForecastDependencyValidationException.InnerException is LockedWeatherForecastException)
            {
                return Locked(weatherForecastDependencyValidationException.InnerException);
            }
            catch (WeatherForecastDependencyValidationException weatherForecastDependencyValidationException)
            {
                return BadRequest(weatherForecastDependencyValidationException);
            }
            catch (WeatherForecastDependencyException weatherForecastDependencyException)
            {
                return InternalServerError(weatherForecastDependencyException);
            }
            catch (WeatherForecastServiceException weatherForecastServiceException)
            {
                return InternalServerError(weatherForecastServiceException);
            }
        }
    }
}
