//using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Service.Interface;
using ECommerce.ViewModels;
using AutoMapper;

namespace ECommerce.Service.Repository
{
    public class StoreRP: IStore
    {
        private readonly EcommerceDbContext db;
        private readonly IMapper mapper;
        public StoreRP(EcommerceDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<List<StoreVM>> GetAll()
        {
            var list = await db.Stores.ToListAsync();
            var storelist = mapper.Map<List<StoreVM>>(list);
            return storelist;
        }
        public async Task<IActionResult> Create(StoreVM storeVM)
        {
            try
            {
                Store store = new Store
                {
                    StoreId = storeVM.StoreId,
                    Name = storeVM.Name,
                };
                db.Stores.Add(store);
                await db.SaveChangesAsync();
                return new JsonResult(new { success = true, message = "Workshop created successfully!" });
            }
            catch (Exception ex)
            {
                var ErrorMessage = ex.Message;
                return new JsonResult(ErrorMessage);
            }
        }

        public async Task<IList<Store>> GetAllStores()
        {
            return await db.Stores.ToListAsync();
        }
    }

}

