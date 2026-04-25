namespace Online_Store_Backend_WebAPI.Models.VOs;

public record GameMediumVo
{
    public ulong Id { get; init; }

    public ulong GameId { get; init; }

    public string Type { get; init; } = string.Empty;

    public string Url { get; init; } = string.Empty;

    public int SortOrder { get; init; }

    public DateTime CreatedAt { get; init; }
}
