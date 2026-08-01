namespace Online_Store_Backend_WebAPI.Models.DTOs;

public record OptionKindDto
{
    public string CodeKind { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }
}
