using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Queries.GetTodos;
using Todo.Application.Commands.CreateTodo;
using Todo.Application.Queries.GetTodoById;
using Todo.Application.Commands.DeleteTodo;
using Todo.Application.Commands.UpdateTodo;

namespace Todo.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetTodosHandler>();
        services.AddScoped<CreateTodoHandler>();
        services.AddScoped<GetTodoByIdHandler>();
        services.AddScoped<DeleteTodoHandler>();
        services.AddScoped<UpdateTodoHandler>();
        return services;
    }
}