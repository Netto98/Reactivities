using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")] // localhost:5000/WeatherForecast
public class WeatherForecastController : ControllerBase
{
    // Array of possible weather summaries.
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // Logger instance for logging information and errors.
    private readonly ILogger<WeatherForecastController> _logger;

    /// <summary>
    /// Constructor that initializes the WeatherForecastController with a logger.
    /// </summary>
    /// <param name="logger">An ILogger instance for logging within this controller.</param>
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger; // Dependency injection of logger for logging operations.
    }

    /// <summary>
    /// Handles GET requests to retrieve a weather forecast.
    /// </summary>
    /// <returns>A collection of WeatherForecast objects.</returns>
    [HttpGet(Name = "GetWeatherForecast")] // Defines the endpoint as a GET request, with a route name "GetWeatherForecast".
    public IEnumerable<WeatherForecast> Get()
    {
        // Generates a list of WeatherForecast objects, with random temperatures and summaries, for the next 5 days.
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)), // Sets the date to today + index days.
            TemperatureC = Random.Shared.Next(-20, 55), // Generates a random temperature in Celsius.
            Summary = Summaries[Random.Shared.Next(Summaries.Length)] // Picks a random summary from the predefined array.
        })
        .ToArray(); // Converts the result to an array to fulfill IEnumerable return type.
    }
}
