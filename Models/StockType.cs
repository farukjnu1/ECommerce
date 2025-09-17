using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class StockType
{
    public int StockTypeId { get; set; }

    public string? StockTypeName { get; set; }

    public virtual ICollection<Ledger> Ledgers { get; set; } = new List<Ledger>();
}
