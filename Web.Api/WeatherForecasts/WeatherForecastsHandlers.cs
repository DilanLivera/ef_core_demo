namespace Web.Api.WeatherForecasts;

internal static class WeatherForecastsHandlers
{
    internal static readonly Func<WeatherForecast[]> GetWeatherForecasts = () => Enumerable
        .Range(1, 5)
        .Select(index =>
        {
            var summaryIndex = Random.Shared.Next(WeatherForecastSummaries.Value.Count);
            return new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC: Random.Shared.Next(-20, 55),
                Summary: WeatherForecastSummaries.Value
                    .Where((_, i) => i == summaryIndex)
                    .First()
            );
        })
        .ToArray();
}
