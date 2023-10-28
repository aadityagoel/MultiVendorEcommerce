using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.ViewComponents
{
    [ViewComponent(Name = "NavbarCart")]
    public class NavbarCartViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index");
        }
    }
}
