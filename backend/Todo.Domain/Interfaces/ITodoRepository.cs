using Todo.Domain.Entities;

namespace Todo.Domain.Interfaces;

public interface ITodoRepository
{
    Task<List<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetByIdAsync(Guid id);
    Task CreateAsync(TodoItem todo);
    Task DeleteAsync(Guid id);
}