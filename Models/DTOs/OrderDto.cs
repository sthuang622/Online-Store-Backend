namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record OrderDto
{
    public ulong Id { get; init; }

    public ulong UserId { get; init; }

    public string Status { get; init; } = string.Empty;

    public string? RegionCode { get; init; }

    public string CurrencyCode { get; init; } = string.Empty;

    public long SubtotalMinor { get; init; }

    public long TaxMinor { get; init; }

    public long TotalMinor { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime? PaidAt { get; init; }
}
