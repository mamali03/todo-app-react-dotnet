using Todo.Application.DTOs;
using Todo.Domain.Interfaces;
//using System.Linq;

namespace Todo.Application.Queries.GetTodos;

public class GetTodosHandler
{
    public readonly ITodoRepository _todoRepository;
    public GetTodosHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<List<TodoDto>> Handle()
    {
        var todos = await _todoRepository.GetAllAsync();

        return todos.Select(todo => new TodoDto{
            Id = todo.Id,
            Title = todo.Title,
            IsCompleted = todo.IsCompleted
        }).ToList();
    }
}