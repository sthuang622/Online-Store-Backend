namespace Online_Store_Backend_WebAPI.Models.VOs;

public record TagVo
{
    public ulong Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string Slug { get; init; } = string.Empty;
}
