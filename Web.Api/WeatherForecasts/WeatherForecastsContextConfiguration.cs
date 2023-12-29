namespace Web.Api.WeatherForecasts;

internal sealed class WeatherForecastsContextConfiguration
{
    public const string SectionName = "WeatherForecastsContext";
    public string Host { get; init; } = "";
    public string UserId { get; init; } = "";
    public string Password { get; init; } = "";
}
