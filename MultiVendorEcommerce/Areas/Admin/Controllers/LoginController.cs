using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiVendorEcommerce.Models;
using MultiVendorEcommerce.Repositories;
using MultiVendorEcommerce.Security;
using System.Security.Claims;

namespace MultiVendorEcommerce.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/login")]
    public class LoginController : Controller
    {
        private IAccountRepository _accountRepository;
        public LoginController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string username, string password)
        {
            var account = _accountRepository.Login(username, password, 1);
            if (account == null)
            {
                ViewBag.error = "Invalid";
                return View("Index");
            }
            else
            {
                var securityManager = new SecurityManager();
                securityManager.SignIn(this.HttpContext, account, "Schema_Admin");
                return RedirectToAction("index", "dashboard", new { area = "admin" });
            }
        }

        [Authorize(Roles = "Admin", AuthenticationSchemes = "Schema_Admin")]
        [HttpGet]
        [Route("profile")]
        public IActionResult Profile()
        {
            var user = User.FindFirst(ClaimTypes.Name);
            var username = user.Value;
            var account = _accountRepository.getByUsername(username);
            return View("Profile", account);
        }

        [Authorize(Roles = "Admin", AuthenticationSchemes = "Schema_Admin")]
        [HttpPost]
        [Route("profile")]
        public async Task<IActionResult> Profile(Account account)
        {
            Account accountResult = _accountRepository.GetByIdNoTracking(account.Id).Result;
            //account.RoleId = accountResult.RoleId;
            account.Status = true;
            if (!string.IsNullOrEmpty(account.Password))
            {
                account.ActualPassword = account.Password;
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            }
            else
            {
                account.Password = accountResult.Password;
                account.ActualPassword = accountResult.ActualPassword;
            }
            await _accountRepository.Update(account.Id, account);
            return RedirectToAction("profile", "login", new { area = "admin" });
        }

        [Authorize(Roles = "Admin", AuthenticationSchemes = "Schema_Admin")]
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            var securityManager = new SecurityManager();
            securityManager.SignOut(this.HttpContext, "Schema_Admin");
            return RedirectToAction("index", "login", new { area = "admin" });
        }
    }
}
