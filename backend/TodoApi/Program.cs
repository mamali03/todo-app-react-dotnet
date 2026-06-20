using Todo.Persistence.DependencyInjection;
using Todo.Application.DependencyInjection;
using Todo.Application.Queries.GetTodos;
using TodoApi.Contracts;
using Todo.Application.Commands.CreateTodo;
using Todo.Application.Queries.GetTodoById;
using Todo.Application.Commands.DeleteTodo;
using Todo.Application.Commands.UpdateTodo;
using Todo.Application.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration.GetConnectionString("DefaultConnection")!);
builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

app.MapGet("/", () => "Hello World");

app.MapGet("/api/todos", async (GetTodosHandler handler) =>
{
    return await handler.Handle();
})
.WithName("GetTodos")
.WithSummary("Get all todos")
.WithDescription("Returns all todos from the database")
.Produces<List<TodoDto>>(StatusCodes.Status200OK);

app.MapPost("/api/todos", async (CreateTodoRequest request,CreateTodoHandler handler) => {

    Console.WriteLine($"Received Title: {request.Title}");
    var command = new CreateTodoCommand
    {
        Title = request.Title
    };
    var id = await handler.Handle(command);
    return Results.Created($"/api/todos/{id}",null);
})
.WithName("CreateTodo")
.WithSummary("Create a new todo")
.WithDescription("Creates a new todo item")
.Produces(StatusCodes.Status201Created);

app.MapGet("/api/todos/{id:guid}", async (Guid id, GetTodoByIdHandler handler)=>{

    var query = new GetTodoByIdQuery{
        Id = id
    };
    var todo = await handler.Handle(query);
    
    return todo is null ? Results.NotFound() : Results.Ok(todo);
})
.WithName("GetTodoById")
.WithSummary("Get a todo by id")
.WithDescription("Returns a single todo if it exists")
.Produces<TodoDto>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapDelete("/api/todos/{id:guid}", async(Guid id, DeleteTodoHandler handler) => {

var command = new DeleteTodoCommand{
Id = id
};
var deleted = await handler.Handle(command);

return deleted ? Results.NoContent() : Results.NotFound();

})
.WithName("DeleteTodo")
.WithSummary("Delete a todo")
.WithDescription("Deletes a todo by id")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound);

app.MapPut("/api/todos/{id:guid}",async (Guid id, UpdateTodoRequest request, UpdateTodoHandler handler)=>{

    var command = new UpdateTodoCommand
    {
        Id = id,
        Title = request.Title,
        IsCompleted = request.IsCompleted
    };
    var updated = await handler.Handle(command);

    return updated ? Results.NoContent():Results.NotFound();
})
.WithName("UpdateTodo")
.WithSummary("Update a todo")
.WithDescription("Updates title and completion status")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound);

app.Run();