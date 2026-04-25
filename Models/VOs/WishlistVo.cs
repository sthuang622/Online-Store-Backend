namespace Online_Store_Backend_WebAPI.Models.VOs;

public record WishlistVo
{
    public ulong UserId { get; init; }

    public ulong ProductId { get; init; }

    public DateTime CreatedAt { get; init; }
}
