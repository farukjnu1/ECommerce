using ECommerce.Models;
using ECommerce.Service.Interface;
using ECommerce.Service.Repository;
using ECommerce.Utilities;
using ECommerce.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EcommerceDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceDb")));
builder.Services.AddTransient<ICategory, CategoryRP>();
builder.Services.AddTransient<ISupplier, SupplierRP>();
builder.Services.AddTransient<IInventoryType, InventoryTypeRP>();
builder.Services.AddTransient<IProduct, ProductRP>();
builder.Services.AddTransient<IPurchase, PurchaseRP>();
builder.Services.AddTransient<IUser, UserRP>();
builder.Services.AddTransient<IStore, StoreRP>();
builder.Services.AddTransient<IRole, RoleRP>();
builder.Services.AddTransient<ITransfer, TransferRP>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
