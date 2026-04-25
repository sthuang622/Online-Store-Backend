namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record PublisherMembershipDto
{
    public ulong PublisherId { get; init; }

    public ulong UserId { get; init; }

    public string Role { get; init; } = string.Empty;

    public DateTime CreatedAt { get; init; }
}
