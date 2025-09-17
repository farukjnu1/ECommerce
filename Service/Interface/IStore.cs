using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using ECommerce.ViewModels;

namespace ECommerce.Service.Interface
{
    public interface IStore
    {
        Task<IActionResult> Create(StoreVM storeVM);
        Task<List<StoreVM>> GetAll();
        Task<IList<Store>> GetAllStores();
    }
}
