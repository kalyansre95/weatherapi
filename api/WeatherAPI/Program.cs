var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/weather/today", () =>
{
    return new {
        date = DateTime.UtcNow,
        temperatureC = 24,
        summary = "Sunny"
    };
});

app.MapGet("/weather/forecast/5days", () =>
{
    string[] summaries = { "Sunny", "Rainy", "Cloudy", "Windy", "Snowy" };
    var rng = new Random();

    return Enumerable.Range(1, 5).Select(day => new {
        date = DateTime.UtcNow.AddDays(day),
        temperatureC = rng.Next(-10, 40),
        summary = summaries[rng.Next(summaries.Length)]
    });
});

app.Run();
