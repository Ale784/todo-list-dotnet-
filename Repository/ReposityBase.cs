using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoList.Contracts;
using TodoList.models.context;

namespace TodoList.Repositoy;

public abstract class RepositoryBase<T, TContext> 
    : IRespository<T> where T : class
    where TContext : DbContext
{
    protected DbContext context;

    public RepositoryBase(TContext context){
        this.context = context;
    }

    public Task<T> Create(T entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
       return !trackChanges?
              context.Set<T>()
              .AsNoTracking()
              : context.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges?
                context.Set<T>().Where(expression)
                .AsTracking()
                :context.Set<T>().Where(expression);
    }  

    public Task<T> Remove(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> Update(T entity)
    {
        throw new NotImplementedException();
    }
}