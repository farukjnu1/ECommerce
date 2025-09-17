using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Service.Interface;
using ECommerce.ViewModels;

namespace ECommerce.Service.Repository
{
    public class InventoryTypeRP : IInventoryType
    {
        private readonly EcommerceDbContext db;
        private readonly IMapper mapper;
        public InventoryTypeRP(EcommerceDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<List<InventoryTypeVM>> GetAll()
        {
            var list = await db.InventoryTypes.ToArrayAsync();
            var datalist = mapper.Map<List<InventoryTypeVM>>(list);
            return datalist;
        }
        

        public async Task<IList<InventoryType>> GetAllInventoryType()
        {
            return await db.InventoryTypes.ToListAsync();
        }

        public async Task<InventoryTypeVM> GetById(int id)
        {
            var roleId = await db.InventoryTypes.Where(x => x.InventoryTypeId == id).FirstOrDefaultAsync();
            var data = mapper.Map<InventoryTypeVM>(roleId);
            return data;
        }
    }
}
