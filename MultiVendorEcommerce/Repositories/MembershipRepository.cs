using MultiVendorEcommerce.Models;
using MultiVendorEcommerce.Repositories.EFCore;

namespace MultiVendorEcommerce.Repositories
{
    public class MembershipRepository : GenericRepository<Membership>, IMembership
    {
        public MembershipRepository(DatabaseContextEntities entities) : base(entities) 
        {

        }
    }
}
