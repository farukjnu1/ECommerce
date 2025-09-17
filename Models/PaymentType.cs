using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class PaymentType
{
    public int Id { get; set; }

    public string? PaymentTypeName { get; set; }

    public virtual Payment? Payment { get; set; }
}
