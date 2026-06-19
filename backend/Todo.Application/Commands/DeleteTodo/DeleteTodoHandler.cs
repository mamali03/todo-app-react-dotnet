using Todo.Domain.Interfaces;

namespace Todo.Application.Commands.DeleteTodo;

public class DeleteTodoHandler
{
    public readonly ITodoRepository _todoRepository;

    public DeleteTodoHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<bool> Handle(DeleteTodoCommand command)
    {
        return await _todoRepository.DeleteAsync(command.Id);
    }
}