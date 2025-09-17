//using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Service.Interface;
//using ECommerce.Utilities;
using ECommerce.ViewModels;
using AutoMapper;

namespace ECommerce.Service.Repository
{
    public class ProductRP : IProduct
    {
        private readonly EcommerceDbContext db;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment en;
        public ProductRP(EcommerceDbContext db, IMapper mapper, IWebHostEnvironment en)
        {
            this.db = db;
            this.mapper = mapper;
            this.en = en;
        }

        public async Task<List<ProductVM>> GetAll()
        {
            var list = await db.Products.Include(p => p.Category).ToListAsync();
            var productList = mapper.Map<List<ProductVM>>(list);
            return productList;
        }

        public async Task<IActionResult> Create(ProductVM model)
        {
            try
            {
                Product product = new Product()
                {
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    Price = model.Price,
                    PartNo = model.PartNo,
                    Description = model.Description ?? "",
                    CategoryId = model.CategoryId,
                };

                if (model.Image != null)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    var filePath = Path.Combine(en.WebRootPath, "Images", uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    product.ImageName = uniqueFileName; 
                }
                else
                {
                    product.ImageName = "default_image.png"; 
                }

                db.Products.Add(product);
                await db.SaveChangesAsync();

                return new OkResult(); 
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return new BadRequestObjectResult(error); 
            }
        }

        public async Task<IList<Product>> GetAllProducts()
        {
            return await db.Products.ToListAsync();
        }
    }


}
