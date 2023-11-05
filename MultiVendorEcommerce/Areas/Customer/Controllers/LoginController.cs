using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.Areas.Customer.Controllers
{
    [Area("customer")]
    [Route("customer/login")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
