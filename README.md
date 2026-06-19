# todo-app-react-dotnet

TaskFlow
A full-stack task management system built using ASP.NET Core, React, TypeScript, EF Core and SQLite.
The project follows Clean Architecture principles with clear separation between Domain, Application, Persistence and API layers.

Objectives
This project was built to learn and demonstrate:
Clean Architecture
ASP.NET Core Minimal APIs
Dependency Injection
Repository Pattern
Entity Framework Core
SQLite
CQRS-style Commands and Queries
React + TypeScript (Upcoming)
AI Integration (Planned)

Architecture Overview
┌─────────────────┐
│ React Frontend  │
└────────┬────────┘
         │ HTTP
         ▼
┌─────────────────┐
│ ASP.NET API     │
└────────┬────────┘
         ▼
┌─────────────────┐
│ Application     │
│ Commands        │
│ Queries         │
│ Handlers        │
└────────┬────────┘
         ▼
┌─────────────────┐
│ Repository      │
└────────┬────────┘
         ▼
┌─────────────────┐
│ EF Core         │
└────────┬────────┘
         ▼
┌─────────────────┐
│ SQLite          │
└─────────────────┘

Solution Structure
backend/

├── Todo.Domain
│   ├── Entities
│   └── Interfaces
│
├── Todo.Application
│   ├── Commands
│   ├── Queries
│   └── DependencyInjection
│
├── Todo.Persistence
│   ├── Data
│   ├── Repositories
│   ├── Migrations
│   └── DependencyInjection
│
└── TodoApi
    ├── Contracts
    └── Program.cs

Layer Responsibilities
Domain
Contains core business objects.
Examples:
TodoItem
ITodoRepository
Rules:
No EF Core
No ASP.NET
No infrastructure dependencies

Application
Contains use cases.
Examples:
CreateTodoCommand
CreateTodoHandler
GetTodosHandler
UpdateTodoHandler
DeleteTodoHandler
Responsibilities:
Business logic
Validation
Workflow orchestration

Persistence
Contains data access logic.
Examples:
AppDbContext
TodoRepository
Responsibilities:
Database communication
EF Core configuration
Migrations

API
Contains HTTP endpoints.
Responsibilities:
Request handling
Response generation
Dependency Injection setup
Route definitions

Request Flow Example
Create Todo
POST /api/todos
      │
      ▼
CreateTodoRequest
      │
      ▼
CreateTodoCommand
      │
      ▼
CreateTodoHandler
      │
      ▼
ITodoRepository
      │
      ▼
TodoRepository
      │
      ▼
AppDbContext
      │
      ▼
SQLite Database

Current Features
Completed:
Create Todo
Get All Todos
Get Todo By Id
Update Todo
Delete Todo

API Endpoints
Get All Todos
GET /api/todos

Get Todo By Id
GET /api/todos/{id}

Create Todo
POST /api/todos
Request:
{
  "title": "Learn Clean Architecture"
}

Update Todo
PUT /api/todos/{id}
Request:
{
  "title": "Learn ASP.NET Core",
  "isCompleted": true
}

Delete Todo
DELETE /api/todos/{id}

Technologies Used
Backend
ASP.NET Core 10
C#
Entity Framework Core
SQLite
Architecture
Clean Architecture
Repository Pattern
Dependency Injection
Development
Git
GitHub
GitHub Codespaces
Frontend (Upcoming)
React
TypeScript
Vite

Key Learnings
Why Dependency Injection?
Allows application components to depend on abstractions instead of concrete implementations.
Benefits:
Loose coupling
Easier testing
Better maintainability

Why Repository Pattern?
Separates data access logic from business logic.
Benefits:
Cleaner architecture
Easier testing
Centralized database access

Why is the Id passed in the route for Update?
Example:
PUT /api/todos/{id}
The route identifies the resource.
The request body contains the new state of that resource.
This avoids inconsistencies between route and request body identifiers.

Why does the API return HTTP status codes?
The API layer is responsible for translating application results into HTTP responses.
Examples:
200 OK
204 No Content
404 Not Found
The Repository and Application layers should not contain HTTP-specific concerns.

Future Enhancements
Planned:
Swagger/OpenAPI
React Frontend
Task Filtering
Search
Authentication & Authorization
Docker
CI/CD Pipeline
AI Task Suggestions
Cloud Deployment

Author
Built as a learning project to gain hands-on experience with modern backend development and Clean Architecture principles.
