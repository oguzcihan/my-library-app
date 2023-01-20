using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class CategoryRepository: EfRepositoryBase<Category, MyLibraryDbContext>,ICategoryRepository
    {
        public CategoryRepository(MyLibraryDbContext context) : base(context)
        {
        }
    }
}
