using System;
using System.Collections.Generic;

namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class Order
{
    public ulong Id { get; set; }

    public ulong UserId { get; set; }

    public string Status { get; set; } = null!;

    public string? RegionCode { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public long SubtotalMinor { get; set; }

    public long TaxMinor { get; set; }

    public long TotalMinor { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? PaidAt { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserLibrary> UserLibraries { get; set; } = new List<UserLibrary>();
}
