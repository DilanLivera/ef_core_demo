namespace Web.Api;

internal static class ServiceRegistration
{
    internal static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
