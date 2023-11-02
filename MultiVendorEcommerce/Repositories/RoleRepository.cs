using MultiVendorEcommerce.Models;
using MultiVendorEcommerce.Repositories.EFCore;

namespace MultiVendorEcommerce.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRole
    {
        public RoleRepository(DatabaseContextEntities entities) : base(entities) 
        {

        }
    }
}
