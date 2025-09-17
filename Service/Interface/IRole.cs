using Microsoft.AspNetCore.Mvc;
using ECommerce.ViewModels;

namespace ECommerce.Service.Interface
{
    public interface IRole
    {
        Task<IActionResult> Create(RoleVM roleVM);
        Task<List<RoleVM>> GetAll();
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Update(RoleVM roleVM);
        Task<RoleVM> GetById(int id);
    }
}
