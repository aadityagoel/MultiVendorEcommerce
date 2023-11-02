using MultiVendorEcommerce.Models;
using MultiVendorEcommerce.Repositories.EFCore;

namespace MultiVendorEcommerce.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProduct
    {
        public ProductRepository(DatabaseContextEntities entities) : base(entities) 
        {

        }
    }
}
