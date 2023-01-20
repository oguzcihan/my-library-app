using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstracts;
using DataAccess.Context;

namespace DataAccess.Concretes.EntityFramework
{
    public class UserRepository: EfRepositoryBase<User, MyLibraryDbContext>, IUserRepository
    {
        private MyLibraryDbContext _myLibraryDbContext;
        public UserRepository(MyLibraryDbContext context, MyLibraryDbContext myLibraryDbContext) : base(context)
        {
            _myLibraryDbContext = myLibraryDbContext;
        }
        //kullanıcının rolleri çekildi.
        public List<OperationClaim> GetClaims(User user)
        {
            //iki tabloyu join ettim.
            var result = from operationClaim in _myLibraryDbContext.OperationClaims
                         join userOperationClaim in _myLibraryDbContext.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name }; //sonuçta olan claim listesi döndürüldü

            return result.ToList();
        }

    }
}
