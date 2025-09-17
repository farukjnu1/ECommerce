using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Ledger> Ledgers { get; set; } = new List<Ledger>();
}
