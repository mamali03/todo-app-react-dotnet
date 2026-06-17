using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Persistence.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    }

    public DbSet<TodoItem> Todos => Set<TodoItem>();
}