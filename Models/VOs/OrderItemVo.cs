namespace Online_Store_Backend_WebAPI.Models.VOs;

public record OrderItemVo
{
    public ulong Id { get; init; }

    public ulong OrderId { get; init; }

    public ulong ProductId { get; init; }

    public int Quantity { get; init; }

    public long UnitPriceMinor { get; init; }

    public long DiscountMinor { get; init; }

    public long FinalPriceMinor { get; init; }

    public DateTime CreatedAt { get; init; }
}
