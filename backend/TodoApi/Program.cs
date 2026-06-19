using Todo.Persistence.DependencyInjection;
using Todo.Application.DependencyInjection;
using Todo.Application.Queries.GetTodos;
using TodoApi.Contracts;
using Todo.Application.Commands.CreateTodo;
using Todo.Application.Queries.GetTodoById;

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

app.MapPost("/api/todos", async (CreateTodoRequest request,CreateTodoHandler handler) => {

    Console.WriteLine($"Received Title: {request.Title}");
    var command = new CreateTodoCommand
    {
        Title = request.Title
    };
    await handler.Handle(command);
    return Results.Ok("Todo Created");
});

app.MapGet("/api/todos/{id:guid}", async (Guid id, GetTodoByIdHandler handler)=>{

    var query = new GetTodoByIdQuery{
        Id = id
    };
    var todo = await handler.Handle(query);
    
    return todo is null ? Results.NotFound() : Results.Ok(todo);
});

app.Run();