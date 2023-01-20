using System.Linq.Expressions;
using Core.DataAccess.Concretes;

namespace Core.DataAccess.Abstracts;

public interface IRepository<T> : IQuery<T> where T : Entity
{
    T Get(Expression<Func<T, bool>> predicate);
    IList<T> GetList(Expression<Func<T, bool>> filter = null);
    T Add(T entity);
    T Update(T entity);
    T Delete(T entity);
}