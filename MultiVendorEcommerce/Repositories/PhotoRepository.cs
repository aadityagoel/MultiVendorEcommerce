using MultiVendorEcommerce.Models;
using MultiVendorEcommerce.Repositories.EFCore;

namespace MultiVendorEcommerce.Repositories
{
    public class PhotoRepository : GenericRepository<Photo>, IPhoto
    {
        public PhotoRepository(DatabaseContextEntities entities) : base(entities) 
        {

        }
    }
}
