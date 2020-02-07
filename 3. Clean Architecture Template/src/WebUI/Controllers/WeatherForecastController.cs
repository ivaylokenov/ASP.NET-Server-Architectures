using DefaultTemplate.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DefaultTemplate.WebUI.Controllers
{
    [Authorize]
    public class WeatherForecastController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}
