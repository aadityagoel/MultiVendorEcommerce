using Microsoft.AspNetCore.Mvc;

namespace MultiVendorEcommerce.ViewComponents
{
    [ViewComponent(Name = "FeaturedCategorySlider")]
    public class FeaturedCategorySliderViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index");
        }
    }
}
