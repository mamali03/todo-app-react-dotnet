using Todo.Domain.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.Commands.CreateTodo;

public class CreateTodoHandler
{
    private readonly ITodoRepository _todoRepository;

    public CreateTodoHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task Handle(CreateTodoCommand command)
    {
        var todo = new TodoItem()
        {
            Id = Guid.NewGuid(),
            Title = command.Title,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };
        await _todoRepository.CreateAsync(todo);
    }

}