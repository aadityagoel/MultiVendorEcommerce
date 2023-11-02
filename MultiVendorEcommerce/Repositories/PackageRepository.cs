using MultiVendorEcommerce.Models;
using MultiVendorEcommerce.Repositories.EFCore;

namespace MultiVendorEcommerce.Repositories
{
    public class PackageRepository : GenericRepository<Package>, IPackage
    {
        public PackageRepository(DatabaseContextEntities entities) : base(entities) 
        {

        }
    }
}
