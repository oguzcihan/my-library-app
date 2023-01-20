using Core.DataAccess.Abstracts;
using Core.Entities.Concrete;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IUserRepository :IAsyncRepository<User>,IRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
