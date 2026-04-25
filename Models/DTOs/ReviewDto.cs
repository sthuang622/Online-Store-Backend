namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record ReviewDto
{
    public ulong Id { get; init; }

    public ulong UserId { get; init; }

    public ulong ProductId { get; init; }

    public string Rating { get; init; } = string.Empty;

    public string? Body { get; init; }

    public int? PlaytimeMinutesAtReview { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; init; }
}
