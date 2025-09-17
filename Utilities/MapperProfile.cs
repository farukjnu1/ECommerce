using AutoMapper;
using ECommerce.Models;
using ECommerce.ViewModels;

namespace ECommerce.Utilities
{
    public class MapperProfile:Profile
    {
        public MapperProfile() 
        {
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<StockType, StockTypeVM>().ReverseMap();
            CreateMap<Supplier, SupplierVM>().ReverseMap();    
            CreateMap<InventoryType, InventoryTypeVM>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<Purchase, PurchaseVM>().ReverseMap();
            CreateMap<PurchaseDetail, PurchaseDetailVM>().ReverseMap();
            CreateMap<Role, RoleVM>().ReverseMap();   
            CreateMap<UserInfo, UserVM>().ReverseMap();
            CreateMap<Store, StoreVM>().ReverseMap();

        }
    }
}
