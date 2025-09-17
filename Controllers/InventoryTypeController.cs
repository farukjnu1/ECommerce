using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using ECommerce.Service.Interface;
using ECommerce.ViewModels;

namespace ECommerce.Controllers
{
    public class InventoryTypeController : Controller
    {
        private readonly IInventoryType inventoryType;
        public InventoryTypeController(IInventoryType inventoryType)
        {
            this.inventoryType = inventoryType;
        }

        public async Task<IActionResult> Index()
        {
            var list = await inventoryType.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            InventoryTypeVM inventoryTypeVM = new InventoryTypeVM();
            return View(inventoryTypeVM);
        }
   
        
    }
}
