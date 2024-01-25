namespace TodoList.models.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(Guid id) : base($"User with id {id} not found")
    {
    }

}