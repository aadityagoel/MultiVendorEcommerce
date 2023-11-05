using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.Areas.Vendor.Controllers
{
    [Authorize(Roles = "Vendor", AuthenticationSchemes = "Schema_Vendor")]
    [Area("vendor")]
    [Route("vendor/dashboard")]
    public class DashboardController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
