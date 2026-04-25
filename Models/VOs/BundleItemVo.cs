namespace Online_Store_Backend_WebAPI.Models.VOs;

public record BundleItemVo
{
    public ulong BundleProductId { get; init; }

    public ulong ItemProductId { get; init; }

    public int Quantity { get; init; }
}
