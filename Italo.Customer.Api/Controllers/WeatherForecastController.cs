using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Italo.Customer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Endpoint to return the forecast
        /// </summary>
        /// <remarks>
        /// Testing my remarks <br/> <br/>
        ///     Example: http://
        /// </remarks>
        /// <param name="id" example="123">Identifier of item</param>
        /// <returns>List of forecast</returns>
        /// <response code="200">List of forecast</response>
        /// <response code="500">Error to return</response>
        /// <response code="404">List not found</response>
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Produces("application/json")]
        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult Get([FromRoute] int id)
        {
            _logger.LogInformation($"My debug message {id}");
            return Ok(Enumerable.Empty<WeatherForecast>());
        }
    }
}