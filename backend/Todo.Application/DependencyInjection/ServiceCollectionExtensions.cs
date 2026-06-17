using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Queries.GetTodos;

namespace Todo.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetTodosHandler>();
        return services;
    }
}