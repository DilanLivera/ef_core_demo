namespace Web.Api.WeatherForecasts;

internal sealed class WeatherForecast
{
    public int Id { get; init; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public DateTimeOffset Date { get; init; }
    public int TemperatureC { get; init; }
    public string Summary { get; init; } = "";
}
