using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //repository pattern
        //Ientityrepoya product gönderdim
        //
        //ıproductdal a özel bir işlemi burada yazarız. EfProductDalda ise implement ederiz.

    }
}
