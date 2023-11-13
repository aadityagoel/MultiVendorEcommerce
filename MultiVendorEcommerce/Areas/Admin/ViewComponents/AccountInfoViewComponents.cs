using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.Areas.Admin.ViewComponents
{
    [ViewComponent(Name = "AccountInfo")]
    public class AccountInfoViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index");
        }
    }
}
