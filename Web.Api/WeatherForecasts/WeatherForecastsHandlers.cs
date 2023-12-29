using System.Collections.ObjectModel;
using System.Text.Json;
using AutoFixture;
using AutoFixture.Dsl;
using AutoFixture.Kernel;
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
                var forecasts = GetForecasts();

                context.AddRange(forecasts);
                context.SaveChanges();

                var weatherForecastsToLog = JsonSerializer.Serialize(
                    context.WeatherForecasts.ToList().AsReadOnly());
                logger.LogInformation(
                    "{WeatherForecasts} are in the db",
                    weatherForecastsToLog);
            }

            return context
                .WeatherForecasts
                .ToArray()
                .AsReadOnly();
        };

    private static ReadOnlyCollection<WeatherForecast> GetForecasts()
    {
        var fixture = new Fixture();

        ISpecimenBuilder Transformation(
            ICustomizationComposer<WeatherForecast> forecast)
        {
            string SummaryFactory()
            {
                var summaryIndex = Random.Shared
                    .Next(WeatherForecastSummaries.Value.Count);

                return WeatherForecastSummaries.Value
                    .ToArray()[summaryIndex];
            }

            return forecast
                .Without(wf => wf.Id)
                .With(
                    propertyPicker: wf => wf.Summary,
                    valueFactory: SummaryFactory);
        }

        fixture.Customize(
            (Func<ICustomizationComposer<WeatherForecast>, ISpecimenBuilder>)Transformation);

        return fixture
            .CreateMany<WeatherForecast>(count: 100)
            .ToList()
            .AsReadOnly();
    }
}
