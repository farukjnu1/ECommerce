using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Service.Interface;
using ECommerce.ViewModels;

namespace ECommerce.Service.Repository
{
    public class UserRP:IUser
    {
        private readonly EcommerceDbContext db;
        private readonly IMapper mapper;
        public UserRP(EcommerceDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<List<UserVM>> GetAll()
        {
            var list = await db.UserInfos.ToListAsync();
            var userlist = mapper.Map<List<UserVM>>(list);
            return userlist;
        }
        public async Task<IActionResult> Create(UserVM userVM)
        {
            try
            {
                UserInfo users = new UserInfo
                {
                    UserId = userVM.UserId,
                    UserName = userVM.UserName,
                    Mobile = userVM.Mobile,
                    Address = userVM.Address,
                    Email = userVM.Email,
                    IsActive = userVM.IsActive
                };
                db.UserInfos.Add(users);
                await db.SaveChangesAsync();
                return new JsonResult(new { success = true, message = "Supplier created successfully!" });
            }
            catch (Exception ex)
            {
                var ErrorMessage = ex.Message;
                return new JsonResult(ErrorMessage);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var userid = db.UserInfos.Where(sid => sid.UserId == id).FirstOrDefault();
            if (userid != null)
            {
                db.UserInfos.Remove(userid);
                await db.SaveChangesAsync();
                return new OkResult();
            }
            return new BadRequestResult();

        }
        public async Task<IActionResult> Update(UserVM userVM)
        {
            var useredit = await db.UserInfos.FirstOrDefaultAsync(a => a.UserId == userVM.UserId);
            if (useredit == null)
            {
                if (useredit == null)
                    return new NotFoundResult();
            }
            useredit.UserId = userVM.UserId;
            useredit.UserName = userVM.UserName;
            useredit.Mobile = userVM.Mobile;
            useredit.Address = userVM.Address;
            useredit.IsActive = userVM.IsActive;
            db.UserInfos.Update(useredit);
            await db.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<UserVM> GetById(int id)
        {
            var userId = await db.UserInfos.Where(x => x.UserId == id).FirstOrDefaultAsync();
            var data = mapper.Map<UserVM>(userId);
            return data;
        }
    }
}
