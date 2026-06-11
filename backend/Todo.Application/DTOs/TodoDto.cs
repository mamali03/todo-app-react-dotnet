namespace Todo.Application.DTOs;

public class TodoDto
{
    public Guid Id {get; set;}
    public string Title {get; set;} = string.Empty;
    public bool IsCompleted {get; set;}
}