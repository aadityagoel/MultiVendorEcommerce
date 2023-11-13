using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.Areas.Admin.ViewComponents
{
    [ViewComponent(Name = "SideBar")]
    public class SideBarViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index");
        }
    }
}
