namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record CreatePublisherGameRequestDto
{
    public ulong UserId { get; init; }

    public string Name { get; init; } = string.Empty;

    public string Slug { get; init; } = string.Empty;

    public string? ShortDescription { get; init; }

    public string? LongDescription { get; init; }

    public string Status { get; init; } = "draft";

    public DateOnly? ReleaseDate { get; init; }
}
