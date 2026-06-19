using Todo.Application.DTOs;
using Todo.Domain.Interfaces;

namespace Todo.Application.Queries.GetTodoById;

public class GetTodoByIdHandler
{
    private readonly ITodoRepository _todoRepository;

    public GetTodoByIdHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoDetailDto?> Handle(GetTodoByIdQuery query)
    {
        var todo = await _todoRepository.GetByIdAsync(query.Id);
        if (todo is null)
        {
            return null;
        }

        return new TodoDetailDto{
            Id = todo.Id,
            Title = todo.Title,
            IsCompleted = todo.IsCompleted,
            CreatedAt = todo.CreatedAt
        };
    }
}