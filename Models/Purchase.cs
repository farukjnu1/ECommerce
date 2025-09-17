using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public string? Description { get; set; }

    public int? SupplierId { get; set; }

    public decimal? GrandTotal { get; set; }

    public bool? IsApprove { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual Supplier? Supplier { get; set; }
}
