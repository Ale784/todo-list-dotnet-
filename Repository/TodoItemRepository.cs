using TodoList.DTO;
using TodoList.models;
using TodoList.models.context;

namespace TodoList.Repository;

public class TodoItemRepository : RepositoryBase<TodoItem, TodoDbContext>
{
    public TodoItemRepository(TodoDbContext context) : base(context)
    {
        
    }
}