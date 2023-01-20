using Core.DataAccess.Concretes;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : Entity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
