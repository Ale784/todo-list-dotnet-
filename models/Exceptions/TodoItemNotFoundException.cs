namespace TodoList.models.Exceptions;

public class CompanyNotFoundException : NotFoundException
{
    public CompanyNotFoundException(Guid id) : base($"Todo Item with id: {id} not found")
    {

    }
}