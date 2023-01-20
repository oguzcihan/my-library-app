using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IBookRepository:IAsyncRepository<Book>,IRepository<Book>
    {
        //For BookRepository operations
    }
}
