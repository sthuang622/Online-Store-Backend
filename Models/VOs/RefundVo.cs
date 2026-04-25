namespace Online_Store_Backend_WebAPI.Models.VOs;

public record RefundVo
{
    public ulong Id { get; init; }

    public ulong PaymentId { get; init; }

    public long AmountMinor { get; init; }

    public string? Reason { get; init; }

    public DateTime CreatedAt { get; init; }
}
