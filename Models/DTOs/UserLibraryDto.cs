namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record UserLibraryDto
{
    public ulong Id { get; init; }

    public ulong UserId { get; init; }

    public ulong ProductId { get; init; }

    public string Source { get; init; } = string.Empty;

    public ulong? OrderId { get; init; }

    public DateTime GrantedAt { get; init; }
}
