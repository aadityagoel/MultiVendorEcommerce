using MultiVendorEcommerce.Models;
using MultiVendorEcommerce.Repositories.EFCore;

namespace MultiVendorEcommerce.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        public Account Login(string username, string password, int roleId);
        public Account getByUsername(string username);
    }
}
