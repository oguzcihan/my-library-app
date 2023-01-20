using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class BookManager : IBookService
    {
        private IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IDataResult<Book> GetById(int bookId)
        {
            return new SuccessDataResult<Book>(_bookRepository.Get(b => b.Id == bookId));
        }

        public IDataResult<List<Book>> GetList()
        {
            return new SuccessDataResult<List<Book>>(_bookRepository.GetList().ToList());
        }

        public IDataResult<List<Book>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Book>>(_bookRepository.GetList(b => b.CategoryId == categoryId).ToList());
        }

        public IResult Add(Book book)
        {
            _bookRepository.Add(book);
            return new SuccessResult(Messages.BookAdded);
        }

        public IResult Update(Book book)
        {
            _bookRepository.Update(book);
            return new SuccessResult(Messages.BookUpdated);
        }

        public IResult Delete(Book book)
        {
            _bookRepository.Delete(book);
            return new SuccessResult(Messages.BookDeleted);
        }
    }
}
