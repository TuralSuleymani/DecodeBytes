using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace ReportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }
        //start and stop

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return "test";
        }
    }
}
