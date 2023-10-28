using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.ViewComponents
{
    [ViewComponent(Name = "Filter")]
    public class FilterViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index");
        }
    }
}
