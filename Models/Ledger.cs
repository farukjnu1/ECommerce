using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class Ledger
{
    public int LedgerId { get; set; }

    public int? ProductId { get; set; }

    public decimal? Price { get; set; }

    public int? InventoryTypeId { get; set; }

    public int? UserId { get; set; }

    public int? Quantity { get; set; }

    public int? StockTypeId { get; set; }

    public int? StoreId { get; set; }

    public virtual InventoryType? InventoryType { get; set; }

    public virtual Product? Product { get; set; }

    public virtual StockType? StockType { get; set; }

    public virtual Store? Store { get; set; }

    public virtual UserInfo? User { get; set; }
}
