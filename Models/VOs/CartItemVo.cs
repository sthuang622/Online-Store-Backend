namespace Online_Store_Backend_WebAPI.Models.VOs;

public record CartItemVo
{
    public ulong CartId { get; init; }

    public ulong ProductId { get; init; }

    public int Quantity { get; init; }

    public DateTime AddedAt { get; init; }
}
