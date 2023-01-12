using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;

namespace DataAccess.Concretes.EntityFramework
{
    public class UserDal : EntityRepositoryBase<User, MyLibraryContext>, IUserDal
    {
        //kullanıcının rolleri çekildi.
        public List<OperationClaim> GetClaims(User user)
        {
            using var context = new MyLibraryContext();
            //iki tabloyu join ettim.
            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name }; //sonuçta olan claim listesi döndürüldü

            return result.ToList();
        }
    }
}
