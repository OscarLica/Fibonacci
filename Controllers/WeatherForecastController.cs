using FibonacciAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace FibonacciAPI.Controllers
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
        private readonly IFibonacciService _fibonacciService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFibonacciService fibonacciService)
        {
            _logger = logger;
            _fibonacciService = fibonacciService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
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

        /// <summary>
        ///     Obtiene un numero de la serie fibonacci en base al index, serie fibonacci generada hasta el 40
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpGet("/Fibonacci/{index}")]
        public IActionResult GetFibonacci(int index) 
            => Ok(_fibonacciService.GetFibonacciByIndex(index));
        
    }
}