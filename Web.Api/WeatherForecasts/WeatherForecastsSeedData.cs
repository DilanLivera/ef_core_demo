using AutoFixture;
using AutoFixture.Dsl;
using AutoFixture.Kernel;

namespace Web.Api.WeatherForecasts;

internal sealed class WeatherForecastsSeedData
{
    private readonly Fixture _fixture;

    public WeatherForecastsSeedData(Fixture fixture)
    {
        _fixture = fixture;
        _fixture.Customize(
            (Func<ICustomizationComposer<WeatherForecast>, ISpecimenBuilder>)Transformation);
    }

    public IReadOnlyCollection<WeatherForecast> WeatherForecasts => _fixture
        .CreateMany<WeatherForecast>(count: 100)
        .ToList()
        .AsReadOnly();

    private static ISpecimenBuilder Transformation(
        ICustomizationComposer<WeatherForecast> forecast) => forecast
        .Without(wf => wf.Id)
        .With(
            propertyPicker: wf => wf.Summary,
            valueFactory: SummaryFactory);

    private static string SummaryFactory()
    {
        var summaryIndex = Random.Shared
            .Next(WeatherForecastSummaries.Value.Count);

        return WeatherForecastSummaries.Value
            .ToArray()[summaryIndex];
    }
}
