using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Queries.GetTodos;
using Todo.Application.Commands.CreateTodo;
using Todo.Application.Queries.GetTodoById;

namespace Todo.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetTodosHandler>();
        services.AddScoped<CreateTodoHandler>();
        services.AddScoped<GetTodoByIdHandler>();
        return services;
    }
}