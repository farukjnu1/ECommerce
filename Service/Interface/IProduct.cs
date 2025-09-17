using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using ECommerce.ViewModels;

namespace ECommerce.Service.Interface
{
    public interface IProduct
    {
        Task<IActionResult> Create(ProductVM productVM);
        Task<List<ProductVM>> GetAll();
        Task<IList<Product>> GetAllProducts();
    }
}
