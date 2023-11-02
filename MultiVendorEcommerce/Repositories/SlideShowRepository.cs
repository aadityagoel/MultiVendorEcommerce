using MultiVendorEcommerce.Models;
using MultiVendorEcommerce.Repositories.EFCore;

namespace MultiVendorEcommerce.Repositories
{
    public class SlideShowRepository : GenericRepository<SlideShow>, ISlideShow
    {
        public SlideShowRepository(DatabaseContextEntities entities) : base(entities) 
        {

        }
    }
}
