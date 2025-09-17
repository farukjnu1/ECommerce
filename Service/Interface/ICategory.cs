using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using ECommerce.ViewModels;

namespace ECommerce.Service.Interface
{
    public interface ICategory
    {
        Task<IActionResult> Create(CategoryVM categoryVM);
        Task<List<CategoryVM>> GetAll();
        Task<IList<Category>> GetAllCategories();
        //Task<IActionResult> Delete(int id);
        //Task<IActionResult> Update(CategoryVM categoryVM);
        Task<CategoryVM> GetById(int id);
    }
}
