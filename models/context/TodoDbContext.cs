using Microsoft.EntityFrameworkCore;
using TodoList.Repository.Configuration;

namespace TodoList.models.context;

public class TodoDbContext : DbContext {

    public TodoDbContext(DbContextOptions options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
    }

    DbSet<TodoItem> TodoList => Set<TodoItem>();
    DbSet<User> User => Set<User>();

}