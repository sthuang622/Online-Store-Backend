namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record GameDto
{
    public ulong Id { get; init; }

    public ulong PublisherId { get; init; }

    public string Name { get; init; } = string.Empty;

    public string Slug { get; init; } = string.Empty;

    public string? ShortDescription { get; init; }

    public string? LongDescription { get; init; }

    public string Status { get; init; } = string.Empty;

    public DateOnly? ReleaseDate { get; init; }
}
