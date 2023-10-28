using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.ViewComponents
{
    [ViewComponent(Name ="NavbarCategory")]
    public class NavbarCategoryViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index");
        }
    }
}
