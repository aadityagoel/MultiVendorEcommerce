using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.Areas.Vendor.Controllers
{
    [Area("vendor")]
    [Route("vendor/login")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
