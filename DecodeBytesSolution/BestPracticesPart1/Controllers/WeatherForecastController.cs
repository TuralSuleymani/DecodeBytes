using BestPracticesPart1.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BestPracticesPart1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AccountServiceConfig _accountServiceConfig;
        public WeatherForecastController(IOptions<AccountServiceConfig> accountServiceConfig,ILogger<WeatherForecastController> logger)
        {
            try
            {
                _accountServiceConfig = accountServiceConfig.Value;
            }
            catch(OptionsValidationException exp)
            {
                //log
                string err = exp.Message;
            }
            
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
