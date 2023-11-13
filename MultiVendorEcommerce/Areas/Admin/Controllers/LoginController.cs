using Microsoft.AspNetCore.Mvc;
using MultiVendorEcommerce.Repositories;
using MultiVendorEcommerce.Security;

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
    }
}
