namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record PaymentDto
{
    public ulong Id { get; init; }

    public ulong OrderId { get; init; }

    public string Provider { get; init; } = string.Empty;

    public string? ProviderPaymentId { get; init; }

    public string Status { get; init; } = string.Empty;

    public long AmountMinor { get; init; }

    public string CurrencyCode { get; init; } = string.Empty;

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; init; }
}
