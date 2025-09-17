using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class SupplierVM
    {
        [Key]
        public int SupplierId { get; set; }
        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }
        [Required]
        [Phone]
        public string Mobile { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(100)]
        public string Manager { get; set; }
    }
}
