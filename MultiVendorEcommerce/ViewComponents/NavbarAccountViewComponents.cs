using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.ViewComponents
{
    [ViewComponent(Name = "NavbarAccount")]
    public class NavbarAccountViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index");
        }
    }
}
