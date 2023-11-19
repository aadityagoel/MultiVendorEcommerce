using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.Areas.Admin.ViewComponents
{
    [ViewComponent(Name = "ProfileSideBar")]
    public class ProfileSideBarViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index");
        }
    }
}
