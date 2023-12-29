using Web.Api;
using Web.Api.WeatherForecasts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app
    .MapGet(
        pattern: "/weatherforecast",
        handler: WeatherForecastsHandlers.GetWeatherForecasts)
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app
    .MapPost(
        pattern: "/weatherforecast",
        handler: WeatherForecastsHandlers.SeedWeatherForecasts)
    .WithName("SeedWeatherForecast")
    .WithOpenApi();

app.Run();
