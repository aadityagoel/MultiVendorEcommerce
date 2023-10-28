using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.ViewComponents
{
    [ViewComponent(Name = "PopularProducts")]
    public class PopularProductsViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int parameter)
        {
            var model = parameter;

            return View("Index", model);
            //return View("Index");
        }
    }
}
