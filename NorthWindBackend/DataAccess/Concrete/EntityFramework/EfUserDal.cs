using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,NorthwindContext>,IUserDal
    {
        //kullanıcının rolleri çekildi.
        public List<OperationClaim> getClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                //iki tabloyu join ettim.
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim {Id = operationClaim.Id, Name = operationClaim.Name}; //sonuçta olan claim listesi döndürüldü

                return result.ToList();
            }
        }
    }
}
