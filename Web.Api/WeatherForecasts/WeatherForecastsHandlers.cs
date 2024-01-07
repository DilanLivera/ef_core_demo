using System.Collections.ObjectModel;
using System.Text.Json;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.WeatherForecasts;

internal static class WeatherForecastsHandlers
{
    internal static readonly Func<
            WeatherForecastsContext,
            ReadOnlyCollection<WeatherForecast>>
        GetWeatherForecasts = ([FromServices] weatherForecastDb) => weatherForecastDb
            .WeatherForecasts
            .ToArray()
            .AsReadOnly();

    internal static readonly Func<
            WeatherForecastsContext,
            ILogger<Program>,
            ReadOnlyCollection<WeatherForecast>>
        SeedWeatherForecasts = ([FromServices] context, [FromServices] logger) =>
        {
            if (context.WeatherForecasts.Any())
            {
                logger.LogInformation("DB already has weather forecasts");
            }
            else
            {
                var fixture = new Fixture();
                var seedData = new WeatherForecastsSeedData(fixture);

                context.AddRange(seedData.WeatherForecasts);
                context.SaveChanges();

                var weatherForecastsToLog = JsonSerializer.Serialize(
                    context.WeatherForecasts.ToList());
                logger.LogInformation(
                    "{WeatherForecasts} are in the db",
                    weatherForecastsToLog);
            }

            return context
                .WeatherForecasts
                .ToArray()
                .AsReadOnly();
        };
}
