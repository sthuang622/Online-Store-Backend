namespace Online_Store_Backend_WebAPI.Models.VOs;

public record GamePriceVo
{
    public ulong Id { get; init; }

    public ulong GameId { get; init; }

    public string RegionCode { get; init; } = string.Empty;

    public string CurrencyCode { get; init; } = string.Empty;

    public long PriceMinor { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; init; }
}
