using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.ViewModels
{
    public class PurchaseVM
    {
        public int PurchaseId { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string? Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Field is required")]
        public int? SupplierId { get; set; }
        public decimal? GrandTotal { get; set; }
        public bool? IsApprove { get; set; }
        public string? SupplierName { get; set; } = string.Empty;
        public IList<PurchaseDetailVM> PurchaseDetails { get; set; } = new List<PurchaseDetailVM>();
        public List<SelectListItem> Suppliers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Products { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Stores { get; set; } = new List<SelectListItem>();

        public int PurchaseDetailId { get; set; }

        //public int PurchaseId { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public int? ProductId { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public decimal Vat { get; set; }

        public decimal SubTotal { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public int? StoreId { get; set; }

        public string ProductName { get; set; } = string.Empty;
    }
}
