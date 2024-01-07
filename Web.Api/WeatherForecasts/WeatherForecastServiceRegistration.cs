namespace Web.Api.WeatherForecasts;

internal static class WeatherForecastServiceRegistration
{
    internal static IServiceCollection AddWeatherForecast(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<WeatherForecastsContext>();
        services.Configure<WeatherForecastsContextConfiguration>(
            configuration.GetSection(key: WeatherForecastsContextConfiguration.SectionName));

        return services;
    }
}
