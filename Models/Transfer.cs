using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class Transfer
{
    public int TransferId { get; set; }

    public string? Description { get; set; }

    public bool? IsApprove { get; set; }

    public virtual ICollection<TransferDetail> TransferDetails { get; set; } = new List<TransferDetail>();
}
