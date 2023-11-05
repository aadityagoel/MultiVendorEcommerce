using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer", AuthenticationSchemes = "Schema_Customer")]
    [Area("customer")]
    [Route("customer/dashboard")]
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
