namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record ProductDto
{
    public ulong Id { get; init; }

    public string Type { get; init; } = string.Empty;

    public ulong? GameId { get; init; }

    public string Name { get; init; } = string.Empty;

    public string? Slug { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; init; }
}
