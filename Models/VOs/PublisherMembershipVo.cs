namespace Online_Store_Backend_WebAPI.Models.VOs;

public record PublisherMembershipVo
{
    public ulong PublisherId { get; init; }

    public ulong UserId { get; init; }

    public string Role { get; init; } = string.Empty;

    public DateTime CreatedAt { get; init; }
}
