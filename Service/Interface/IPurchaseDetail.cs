using Microsoft.AspNetCore.Mvc;
using ECommerce.ViewModels;

namespace ECommerce.Service.Interface
{
    public interface IPurchaseDetail
    {
        Task<IActionResult> Create(PurchaseDetailVM purchaseDetailVM);
        Task<List<PurchaseDetailVM>> GetAll();
    }
}
