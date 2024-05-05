using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiVendorEcommerce.Models;
using MultiVendorEcommerce.Repositories;

namespace MultiVendorEcommerce.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Schema_Admin")]
    [Area("admin")]
    [Route("admin/package")]
    public class PackageController : Controller
    {
        private IPackage _packageRepository;
        public PackageController(IPackage packageRepository)
        {
            _packageRepository = packageRepository;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.packages = _packageRepository.GetAll();
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            //ViewBag.packages = _packageRepository.GetAll();
            return View("Add", new Package());
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Package package)
        {
            await _packageRepository.Create(package);
            return RedirectToAction("Index", "package", new { area="admin"});
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var package = await _packageRepository.GetById(id);
            return View("Edit", package);
        }

        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id, Package package)
        {
            await _packageRepository.Update(id, package);
            return RedirectToAction("Index", "package", new { area = "admin" });
        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _packageRepository.Delete(id);
            }
            catch (Exception ex) {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("Index", "package", new { area = "admin" });
        }
    }
}
