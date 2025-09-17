using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? PartNo { get; set; }

    public string? Description { get; set; }

    public string? ImageName { get; set; }

    public decimal? Price { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Ledger> Ledgers { get; set; } = new List<Ledger>();

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
