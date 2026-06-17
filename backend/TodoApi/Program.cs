using Todo.Persistence.DependencyInjection;
using Todo.Application.DependencyInjection;
using Todo.Application.Queries.GetTodos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration.GetConnectionString("DefaultConnection")!);
builder.Services.AddApplication();

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

app.MapGet("/api/todos", async (GetTodosHandler handler) =>
{
    return await handler.Handle();
});

app.Run();