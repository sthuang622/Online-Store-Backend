namespace Online_Store_Backend_WebAPI.Models.VOs;

public record UserVo
{
    public ulong Id { get; init; }

    public string Email { get; init; } = string.Empty;

    public string Username { get; init; } = string.Empty;

    public string? PasswordHash { get; init; }

    public string Status { get; init; } = string.Empty;

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; init; }
}
