using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? SaleId { get; set; }

    public int? CustomerId { get; set; }

    public int? PaymentTypeId { get; set; }

    public string? AccNo { get; set; }

    public string? BankName { get; set; }

    public DateTime? Time { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual PaymentType PaymentNavigation { get; set; } = null!;

    public virtual Sale? Sale { get; set; }
}
