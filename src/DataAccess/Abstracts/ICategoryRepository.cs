using Core.DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface ICategoryRepository:IAsyncRepository<Category>,IRepository<Category>
    {
        //Sadece category için kullanılacak bir işlem varsa buraya yazılmalı.
    }
}
