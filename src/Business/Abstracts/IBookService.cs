using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IBookService
    {
        IDataResult<Book> GetById(int bookId);
        IDataResult<List<Book>> GetList();
        IDataResult<List<Book>> GetListByCategory(int categoryId);
        IResult Add(Book book);
        IResult Update(Book book);
        IResult Delete(Book book);
    }
}
