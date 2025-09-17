using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class RoleVM
    {
        [Key]
        public int RoleId { get; set; }
        [StringLength(100)]
        public string RoleName { get; set; }
    }
}
