namespace Todo.Application.Commands.UpdateTodo;

public class UpdateTodoCommand
{
    public Guid Id {get;set;}
    public string Title {get;set;} = string.Empty;
    public bool IsCompleted {get;set;}
}