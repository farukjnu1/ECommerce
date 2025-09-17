using Microsoft.AspNetCore.Mvc;
using ECommerce.ViewModels;

namespace ECommerce.Service.Interface
{
    public interface IPurchase
    {
        
        //Task<IActionResult> ApprovePurchase(int purchaseId);
        Task<List<PurchaseVM>> GetAll();
        Task<PurchaseVM> GetById(int id);
        Task<PurchaseVM> CreateMaster(PurchaseVM purchaseVM);
        Task<PurchaseDetailVM> CreateDetail(PurchaseDetailVM detail);
        Task<PurchaseVM> Approve(PurchaseVM purchaseVM);
        Task<PurchaseDetailVM> RemoveDetail(int id);
    }
}
