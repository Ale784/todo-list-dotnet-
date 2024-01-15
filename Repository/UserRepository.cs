using TodoList.models;
using TodoList.models.context;

namespace TodoList.Repository;

public class UserRepository : RepositoryBase<User, TodoDbContext>
{
    public UserRepository(TodoDbContext context) : base(context)
    {
    }
}