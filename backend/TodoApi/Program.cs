var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

app.MapGet("/", () => "Hello World");

app.MapGet("/weatherforecast", () =>
{
    return new[]
    {
        new { Temp = 25, Summary = "Warm" }
    };
});

app.Run();