Interview Notes - TaskFlow
Why Clean Architecture?
Clean Architecture separates responsibilities into layers.
Benefits:
Maintainability
Testability
Separation of Concerns
Easier replacement of infrastructure
Structure:
API
 ↓
Application
 ↓
Domain

Persistence
 ↓
Domain
Rule:
Inner layers should not depend on outer layers.

Why Dependency Injection?
Dependency Injection provides dependencies from an external container instead of creating them manually.
Bad:
var repository = new TodoRepository();
Good:
public GetTodosHandler(ITodoRepository repository)
{
    _repository = repository;
}
Benefits:
Loose coupling
Easier testing
Easier replacement of implementations

How does ASP.NET know how to create GetTodosHandler?
Registration:
services.AddScoped<GetTodosHandler>();
Handler constructor:
public GetTodosHandler(
    ITodoRepository repository)
ASP.NET:
Creates GetTodosHandler
Sees ITodoRepository is needed
Looks in DI container
Finds TodoRepository registration
Injects it automatically

What happens if a class has multiple constructors?
ASP.NET chooses the constructor it can satisfy using Dependency Injection.
Best practice:
Use a single constructor.

Why Repository Pattern?
Repository Pattern abstracts database access.
Without Repository:
Handler
 ↓
DbContext
With Repository:
Handler
 ↓
Repository
 ↓
DbContext
Benefits:
Separation of concerns
Easier testing
Centralized data access

Why should Repository not return HTTP responses?
Bad:
return Results.NotFound();
Repository should not know about HTTP.
Repository responsibility:
Database operations
API responsibility:
HTTP responses
Correct:
return false;
Then:
return deleted
    ? Results.NoContent()
    : Results.NotFound();

Why return bool from DeleteAsync?
Repository:
true
means deleted.
false
means entity not found.
API decides which HTTP status code to return.

Why is Id passed in the route?
Example:
PUT /api/todos/{id}
Route identifies:
Which resource?
Request body identifies:
What should change?
Avoids conflicting IDs.

Why use Request DTO and Command separately?
API Contract:
UpdateTodoRequest
Application Layer:
UpdateTodoCommand
Benefits:
API remains independent
Application remains independent
Easier future changes

Why not expose Domain Entities directly?
Bad:
API
 ↓
TodoItem
Good:
API
 ↓
DTO
 ↓
Command
 ↓
Domain Entity
Benefits:
Better encapsulation
Easier evolution
Prevents leaking internal structure

What is DbSet?
Example:
public DbSet<TodoItem> Todos => Set<TodoItem>();
Represents a table in the database.
Equivalent to:
SELECT * FROM Todos
operations through EF Core.

Why use Set()?
Generic EF Core method.
Returns the DbSet for the specified entity type.

Why use async/await?
Benefits:
Non-blocking I/O
Better scalability
Efficient thread usage
Example:
await _dbContext.Todos.ToListAsync();

What is EF Core Migration?
Migration is version control for database schema.
Example:
dotnet ef migrations add InitialCreate
Creates migration files.
dotnet ef database update
Applies migration to database.

What is SQLite WAL?
Files:
todos.db
todos.db-wal
todos.db-shm
Purpose:
Write-Ahead Logging
Better performance
Transaction support
Usually ignored in Git.

What is CORS?
Cross-Origin Resource Sharing.
Allows frontend applications from another origin to call the API.
Example:
React:
http://localhost:5173
API:
http://localhost:5054
Different origins require CORS.

Why register services using AddScoped?
Scoped lifetime:
One instance per HTTP request
Good for:
Repositories
Handlers
DbContext

Difference between AddScoped, AddTransient and AddSingleton?
AddTransient
New instance every resolution
AddScoped
One instance per request
AddSingleton
One instance for application lifetime

What is Minimal API?
Instead of Controllers:
[ApiController]
public class TodosController
Use:
app.MapGet(...)
app.MapPost(...)
Benefits:
Less boilerplate
Faster development
Good for small APIs

Why use CreatedAt in Entity?
Stores creation timestamp.
Useful for:
Auditing
Sorting
Reporting

Questions to Practice
Explain your project architecture.
Why did you choose Clean Architecture?
How does Dependency Injection work internally?
Why Repository Pattern?
Why not inject DbContext directly?
Why separate DTOs from Commands?
Why use async/await?
What is a DbSet?
What is EF Core Migration?
Difference between GET, POST, PUT and DELETE?
Difference between 200, 201, 204 and 404?
What is CORS and why is it needed?
What lifetime did you use for repositories and why?
Explain the flow of Create Todo request end-to-end.
If tomorrow you switch SQLite to SQL Server, what changes?
Why should inner layers not depend on outer layers?
What would you improve if this became a production system?
