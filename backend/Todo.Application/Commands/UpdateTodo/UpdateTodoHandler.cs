using Todo.Domain.Entities;
using Todo.Domain.Interfaces;

namespace Todo.Application.Commands.UpdateTodo;

public class UpdateTodoHandler
{
    private readonly ITodoRepository _todoRepository;

    public UpdateTodoHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<bool> Handle(UpdateTodoCommand command)
    {
        var todo = new TodoItem{
            Id = command.Id,
            Title = command.Title,
            IsCompleted = command.IsCompleted
        };

        return await _todoRepository.UpdateAsync(todo);
    }
}