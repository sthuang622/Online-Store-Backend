namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record CartItemDto
{
    public ulong CartId { get; init; }

    public ulong ProductId { get; init; }

    public int Quantity { get; init; }

    public DateTime AddedAt { get; init; }
}
