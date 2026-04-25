namespace Online_Store_Backend_WebAPI.Models.VOs;

public record PublisherVo
{
    public ulong Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string Slug { get; init; } = string.Empty;

    public string? Website { get; init; }

    public string? LogoUrl { get; init; }

    public string? Description { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; init; }
}
