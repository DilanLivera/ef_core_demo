using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Web.Api.WeatherForecasts;

internal sealed class WeatherForecastsContext
    : DbContext
{
    private readonly WeatherForecastsContextConfiguration _configuration;

    public WeatherForecastsContext(
        DbContextOptions<WeatherForecastsContext> options,
        IOptions<WeatherForecastsContextConfiguration> configurationOptions)
        : base(options)
    {
        _configuration = configurationOptions.Value;
        Database.EnsureCreated();
    }

    public required DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder builder)
    {
        var connectionString =
            $"Server={_configuration.Host};Database=ef_core_demo;User Id={_configuration.UserId};Password={_configuration.Password};MultipleActiveResultSets=true;TrustServerCertificate=true";
        builder.UseSqlServer(connectionString);
    }
}
