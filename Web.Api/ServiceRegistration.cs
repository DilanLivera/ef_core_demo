using Web.Api.WeatherForecasts;

namespace Web.Api;

internal static class ServiceRegistration
{
    internal static IServiceCollection AddServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<WeatherForecastsContext>();
        services.Configure<WeatherForecastsContextConfiguration>(
            configuration.GetSection(key: WeatherForecastsContextConfiguration.SectionName));

        services.AddProblemDetails();

        return services;
    }
}
