using MultiVendorEcommerce.Models;
using MultiVendorEcommerce.Repositories.EFCore;

namespace MultiVendorEcommerce.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(DatabaseContextEntities entities) : base(entities) 
        {

        }

        public Account getByUsername(string username)
        {
            return GetAll().SingleOrDefault(a => a.Username.Equals(username));
        }

        public Account Login(string username, string password, int roleId)
        {
            var account = GetAll().SingleOrDefault(a => a.Username.Equals(username) && a.RoleId == roleId && a.Status);
            if (account != null)
            {
                if(BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }
            return null;
        }
    }
}
