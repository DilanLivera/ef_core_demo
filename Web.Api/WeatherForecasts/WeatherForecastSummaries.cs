namespace Web.Api.WeatherForecasts;

internal sealed class WeatherForecastSummaries
{
    private static readonly string[] _summaries =
    [
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    ];

    public static IReadOnlyCollection<string> Value => _summaries.AsReadOnly();
}
