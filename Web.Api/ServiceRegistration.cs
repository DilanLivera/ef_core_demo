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

        services.AddWeatherForecast(configuration);

        services.AddProblemDetails();

        return services;
    }
}
