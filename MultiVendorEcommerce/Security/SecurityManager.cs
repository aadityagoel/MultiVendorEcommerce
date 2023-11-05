using Microsoft.AspNetCore.Authentication;
using MultiVendorEcommerce.Models;
using System.Security.Claims;

namespace MultiVendorEcommerce.Security
{
    public class SecurityManager
    {
        public async void SignIn(HttpContext context, Account account, string schema)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(getUserClaims(account), schema);
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
            await context.SignInAsync(schema, principal);
        }
        public async void SignOut(HttpContext context, string schema)
        {
            await context.SignOutAsync(schema);
        }

        private IEnumerable<Claim> getUserClaims(Account account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.Username));
            //foreach(var roleAccount in account.RoleAccount)
            //{
            claims.Add(new Claim(ClaimTypes.Role, account.Role.Name));
            //}
            return claims;
        }
    }
}
