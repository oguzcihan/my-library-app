using System.Linq.Expressions;
using Core.DataAccess.Concretes;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.DataAccess.Abstracts;

public interface IAsyncRepository<T>:IQuery<T> where T:Entity
{
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}