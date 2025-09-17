using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class InventoryType
{
    public int InventoryTypeId { get; set; }

    public string? Name { get; set; }

    public string? Remarks { get; set; }

    public virtual ICollection<Ledger> Ledgers { get; set; } = new List<Ledger>();
}
