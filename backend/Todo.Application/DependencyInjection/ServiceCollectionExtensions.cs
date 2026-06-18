using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Queries.GetTodos;
using Todo.Application.Commands.CreateTodo;

namespace Todo.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetTodosHandler>();
        services.AddScoped<CreateTodoHandler>();
        return services;
    }
}