using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class StoreVM
    {
        [Key]
        public int StoreId { get; set; }
        public string Name { get; set; }
    }
}
