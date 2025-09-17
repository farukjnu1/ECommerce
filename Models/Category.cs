using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
