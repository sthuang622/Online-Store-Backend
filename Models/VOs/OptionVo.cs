namespace Online_Store_Backend_WebAPI.Models.VOs;

public record OptionVo
{
    public string CodeId { get; init; } = string.Empty;

    public string CodeKind { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }
}
