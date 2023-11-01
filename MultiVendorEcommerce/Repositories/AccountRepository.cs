using MultiVendorEcommerce.Models;
using MultiVendorEcommerce.Repositories.EFCore;

namespace MultiVendorEcommerce.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(DatabaseContextEntities entities) : base(entities) 
        {

        }
    }
}
