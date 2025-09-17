using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public string? Description { get; set; }

    public int? CustomerId { get; set; }

    public decimal? GrandTotal { get; set; }

    public bool? IsApprove { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
