using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class UserInfo
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserPass { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Address { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Ledger> Ledgers { get; set; } = new List<Ledger>();
}
