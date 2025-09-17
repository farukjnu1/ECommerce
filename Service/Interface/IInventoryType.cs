using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using ECommerce.ViewModels;

namespace ECommerce.Service.Interface
{
    public interface IInventoryType
    {
        //Task<IActionResult> Create(InventoryTypeVM inventoryTypeVM);
        Task<List<InventoryTypeVM>> GetAll();
        //Task<IList<InventoryType>> GetAllInventoryType();
        //Task<IActionResult> Delete(int id);
        //Task<IActionResult> Update(InventoryTypeVM inventoryTypeVM);
        Task<InventoryTypeVM> GetById(int id);
    }
}
