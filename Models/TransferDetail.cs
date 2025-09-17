using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TransferDetail
{
    public int Id { get; set; }

    public int? TransferId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? SourceStore { get; set; }

    public int? DestinationStore { get; set; }

    public virtual Transfer? Transfer { get; set; }
}
