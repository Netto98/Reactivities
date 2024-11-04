namespace API;

public class WeatherForecast
{
    // List of 4 Properties
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

// ? means optional (nullable)
    public string Summary { get; set; }
}
