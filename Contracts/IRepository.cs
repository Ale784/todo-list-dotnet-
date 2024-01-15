using System.Linq.Expressions;

namespace TodoList.Contracts;

public interface IRespository<T> where T: class
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>>expression, bool trackChanges);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Remove(T entity);

}