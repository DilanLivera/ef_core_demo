using Web.Api;
using Web.Api.WeatherForecasts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app
    .MapGet(
        pattern: "/weatherforecast",
        handler: WeatherForecastsHandlers.GetWeatherForecasts)
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();
