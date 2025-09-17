using Microsoft.AspNetCore.Mvc;
using ECommerce.ViewModels;
using static ECommerce.ViewModels.TransferVM;

namespace ECommerce.Service.Interface
{
    public interface ITransfer
    {
        Task<List<TransferVM>> GetAll();
        Task<TransferVM> GetById(int id);
        Task<TransferVM> CreateMaster(TransferVM purchaseVM);
        Task<TransferDetailVM> CreateDetail(TransferDetailVM detail);
        Task<TransferVM> Approve(TransferVM purchaseVM);
        Task<TransferVM.TransferDetailVM> RemoveDetail(int id);
    }
}
