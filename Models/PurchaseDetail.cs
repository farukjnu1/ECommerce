using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class PurchaseDetail
{
    public int PurchaseDetailId { get; set; }

    public int? PurchaseId { get; set; }

    public int? ProductId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public decimal? Vat { get; set; }

    public decimal? SubTotal { get; set; }

    public int? StoreId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Purchase? Purchase { get; set; }
}
