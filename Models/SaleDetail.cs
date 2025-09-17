using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class SaleDetail
{
    public int SaleDetailsId { get; set; }

    public int? SaleId { get; set; }

    public int? ProductId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public decimal? Vat { get; set; }

    public decimal? SubTotal { get; set; }

    public int? StoreId { get; set; }

    public int? CustomerId { get; set; }
}
