namespace Core.DataAccess.Abstracts;

public interface IQuery<T>
{
    IQueryable<T> Query();
}