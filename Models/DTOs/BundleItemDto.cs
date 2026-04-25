namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record BundleItemDto
{
    public ulong BundleProductId { get; init; }

    public ulong ItemProductId { get; init; }

    public int Quantity { get; init; }
}
