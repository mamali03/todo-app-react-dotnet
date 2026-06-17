using Todo.Domain.Interfaces;
using Todo.Persistence.Data;
using Todo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Todo.Persistence.Repositories;

public class TodoRepository: ITodoRepository
{
    public readonly AppDbContext _dbContext;
    public TodoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
        return await _dbContext.Todos.ToListAsync(); 
    }

    public async Task<TodoItem?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Todos.FindAsync(id);
    }

    public async Task CreateAsync(TodoItem todo)
    {
        await _dbContext.Todos.AddAsync(todo);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var todo = await _dbContext.Todos.FindAsync(id);
        if(todo is null)
        {
            return;
        }
        _dbContext.Todos.Remove(todo);
        await _dbContext.SaveChangesAsync();
    }
}