using System;
using System.Collections.Generic;

namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class Payment
{
    public ulong Id { get; set; }

    public ulong OrderId { get; set; }

    public string Provider { get; set; } = null!;

    public string? ProviderPaymentId { get; set; }

    public string Status { get; set; } = null!;

    public long AmountMinor { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<Refund> Refunds { get; set; } = new List<Refund>();
}
