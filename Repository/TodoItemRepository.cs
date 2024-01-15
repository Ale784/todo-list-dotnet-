using TodoList.models;
using TodoList.models.context;

namespace TodoList.Repositoy;

public class TodoItemRepository : RepositoryBase<TodoItem, TodoDbContext>
{
    public TodoItemRepository(TodoDbContext context) : base(context)
    {
        
    }
}