using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class BookRepository : EfRepositoryBase<Book, MyLibraryDbContext>, IBookRepository
    {
        public BookRepository(MyLibraryDbContext context) : base(context)
        {
        }
    }
}
