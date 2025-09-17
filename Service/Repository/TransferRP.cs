using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Service.Interface;
using ECommerce.ViewModels;
using static ECommerce.ViewModels.TransferVM;

namespace ECommerce.Service.Repository
{
    public class TransferRP : ITransfer
    {
        private readonly EcommerceDbContext db;
        private readonly IMapper mapper;

        public TransferRP(EcommerceDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<TransferVM>> GetAll()
        {
            var list = await (from t in db.Transfers
                              select new TransferVM()
                              {
                                  TransferId = t.TransferId,
                                  Description = t.Description,
                                  IsApprove = t.IsApprove
                              }).ToListAsync();
            return list;
        }

        public async Task<TransferVM> GetById(int id)
        {
            TransferVM oTransfer = null;
            var transfer = await (from t in db.Transfers
                                  where t.TransferId == id
                                  select new TransferVM()
                                  {
                                      TransferId = t.TransferId,
                                      Description = t.Description,
                                      IsApprove = t.IsApprove
                                  }).FirstOrDefaultAsync();
            if (transfer != null)
            {
                var transferDetailList = await (from td in db.TransferDetails
                                                  join p in db.Products on td.ProductId equals p.ProductId
                                                  join sor in db.Stores on td.SourceStore equals sor.StoreId
                                                  join des in db.Stores on td.DestinationStore equals des.StoreId
                                                  where td.TransferId == id
                                                  select new TransferVM.TransferDetailVM()
                                                  {
                                                      TransferId = id,
                                                      SourceStore = td.SourceStore,
                                                      DestinationStore = td.DestinationStore,
                                                      ProductId = p.ProductId,
                                                      Id = td.Id,
                                                      Quantity = td.Quantity,
                                                      SourceStoreName = sor.Name,
                                                      DestinationStoreName = des.Name,
                                                      ProductName = p.ProductName
                                                  }).ToListAsync();
                oTransfer = transfer;
                oTransfer.TransferDetails = transferDetailList;

            }
            return oTransfer;
        }

        public async Task<TransferVM> CreateMaster(TransferVM modelVM)
        {
            try
            {
                #region Master insert/update
                var model = await db.Transfers.Where(x => x.TransferId == modelVM.TransferId).FirstOrDefaultAsync();
                if (model == null)
                {
                    model = new Transfer
                    {
                        TransferId = modelVM.TransferId,
                        Description = modelVM.Description
                    };
                    db.Transfers.Add(model);
                    await db.SaveChangesAsync();
                    modelVM.TransferId = model.TransferId;
                }
                else
                {
                    model.TransferId = modelVM.TransferId;
                    model.Description = modelVM.Description;
                    model.IsApprove = modelVM.IsApprove;
                    await db.SaveChangesAsync();
                }
                #endregion

                return modelVM;
            }
            catch (Exception ex)
            {
                var ErrorMessage = ex.Message;

                return modelVM;
            }
        }

        public async Task<TransferVM.TransferDetailVM> CreateDetail(TransferVM.TransferDetailVM detail)
        {
            try
            {
                var model = new TransferDetail
                {
                    TransferId = detail.TransferId,
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity,
                    SourceStore = detail.SourceStore,
                    DestinationStore = detail.DestinationStore,
                };
                db.TransferDetails.Add(model);
                await db.SaveChangesAsync();
                detail.Id = model.Id;
                detail.TransferId = model.TransferId;
                return detail;
            }
            catch (Exception ex)
            {
                var ErrorMessage = ex.Message;
                return detail;
            }
        }

        public async Task<TransferVM> Approve(TransferVM modelVM)
        {
            try
            {
                #region Transfer
                foreach (var detail in modelVM.TransferDetails)
                {
                    #region Issue (from source-store)
                    Ledger ledger1 = new Ledger();
                    ledger1.Quantity = detail.Quantity;
                    ledger1.InventoryTypeId = 3; // transfer
                    ledger1.StockTypeId = 1; // issue
                    ledger1.StoreId = detail.SourceStore;
                    ledger1.ProductId = detail.ProductId;
                    //ledger1.UserId = Login UserID
                    db.Ledgers.Add(ledger1);
                    await db.SaveChangesAsync();

                    var oStock1 = (from x in db.Stocks
                                  where x.ProductId == detail.ProductId && x.StoreId == detail.SourceStore
                                  select x).FirstOrDefault();
                    if (oStock1 != null)
                    {
                        oStock1.ProductId = detail.ProductId;
                        oStock1.Quantity -= detail.Quantity;
                        oStock1.StoreId = detail.SourceStore;
                        db.SaveChanges();
                    }
                    else
                    {
                        Stock stock1 = new Stock();
                        stock1.ProductId = detail.ProductId;
                        stock1.Quantity = detail.Quantity;
                        stock1.StoreId = detail.SourceStore;
                        db.Add(stock1);
                        db.SaveChanges();
                    }
                    #endregion
                    #region Receive (from source-store)
                    Ledger ledger2 = new Ledger();
                    ledger2.Quantity = detail.Quantity;
                    ledger2.InventoryTypeId = 3; // transfer
                    ledger2.StockTypeId = 2; // receive
                    ledger2.StoreId = detail.SourceStore;
                    ledger2.ProductId = detail.ProductId;
                    //ledger2.UserId = Login UserID
                    db.Ledgers.Add(ledger2);
                    await db.SaveChangesAsync();

                    var oStock2 = (from x in db.Stocks
                                  where x.ProductId == detail.ProductId && x.StoreId == detail.DestinationStore
                                  select x).FirstOrDefault();
                    if (oStock2 != null)
                    {
                        oStock2.ProductId = detail.ProductId;
                        oStock2.Quantity += detail.Quantity;
                        oStock2.StoreId = detail.SourceStore;
                        db.SaveChanges();
                    }
                    else
                    {
                        Stock stock2 = new Stock();
                        stock2.ProductId = detail.ProductId;
                        stock2.Quantity = detail.Quantity;
                        stock2.StoreId = detail.SourceStore;
                        db.Add(stock2);
                        db.SaveChanges();
                    }
                    #endregion
                    #region Approve
                    var model = (from x in db.Transfers
                                 where x.TransferId == modelVM.TransferId
                                 select x).FirstOrDefault();
                    if (model != null)
                    {
                        model.IsApprove = true;
                        db.SaveChanges();
                    }
                    #endregion
                }
                #endregion
                return modelVM;
            }
            catch (Exception ex)
            {
                var ErrorMessage = ex.Message;
                return modelVM;
            }
        }

        public async Task<TransferVM.TransferDetailVM> RemoveDetail(int detailID)
        {
            TransferVM.TransferDetailVM modelVM = new TransferVM.TransferDetailVM();
            try
            {
                var model = await db.TransferDetails.Where(x => x.Id == detailID).FirstOrDefaultAsync();
                if (model != null)
                {
                    db.TransferDetails.Remove(model);
                    await db.SaveChangesAsync();
                    modelVM.Id = model.Id;
                    modelVM.TransferId = model.TransferId;
                }
                return modelVM;
            }
            catch (Exception ex)
            {
                var ErrorMessage = ex.Message;
                return modelVM;
            }
        }

    }
}
