namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record CartDto
{
    public ulong Id { get; init; }

    public ulong UserId { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; init; }
}
