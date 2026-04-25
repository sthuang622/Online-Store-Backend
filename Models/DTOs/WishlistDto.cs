namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record WishlistDto
{
    public ulong UserId { get; init; }

    public ulong ProductId { get; init; }

    public DateTime CreatedAt { get; init; }
}
