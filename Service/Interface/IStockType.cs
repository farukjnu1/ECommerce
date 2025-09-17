using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using ECommerce.ViewModels;

namespace ECommerce.Service.Interface
{
    public interface IStockType
    {
        Task<IActionResult> Create(StockTypeVM stockTypeVM);
        Task<List<StockTypeVM>> GetAll();
        //Task<IList<StockType>> GetAllStockType();
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Update(StockTypeVM stockTypeVM);
        Task<StockTypeVM> GetById(int id);
    }
}
