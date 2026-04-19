using System;
using System.Collections.Generic;

namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class OrderItem
{
    public ulong Id { get; set; }

    public ulong OrderId { get; set; }

    public ulong ProductId { get; set; }

    public int Quantity { get; set; }

    public long UnitPriceMinor { get; set; }

    public long DiscountMinor { get; set; }

    public long FinalPriceMinor { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
