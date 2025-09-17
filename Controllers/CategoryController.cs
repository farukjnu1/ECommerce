using Microsoft.AspNetCore.Mvc;
//using NuGet.Packaging.Signing;
using ECommerce.Models;
using ECommerce.Service.Interface;
using ECommerce.Service.Repository;
using ECommerce.ViewModels;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory category;
        public CategoryController(ICategory category)
        {
            this.category = category;
        }
        public async Task<IActionResult> Index()
        {
            var catlist = await category.GetAll();
            return View(catlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CategoryVM categoryVM = new CategoryVM();
            return View(categoryVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                var result = await category.Create(categoryVM);
                return RedirectToAction("Index");
            }
            return View(categoryVM);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var allSuppliers = await category.GetAll();
            var supplierVM = allSuppliers.FirstOrDefault(s => s.CategoryId == id);

            if (supplierVM == null)
            {
                return NotFound();
            }
            return View(supplierVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await category.GetById(id);
            return View(data);
        }
        
    }
}
