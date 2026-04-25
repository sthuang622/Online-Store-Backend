namespace Online_Store_Backend_WebAPI.Models.VOs;

public record CartVo
{
    public ulong Id { get; init; }

    public ulong UserId { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; init; }
}
