namespace Online_Store_Backend_WebAPI.Models.VOs;

public record AuditLogVo
{
    public ulong Id { get; init; }

    public ulong? ActorUserId { get; init; }

    public string Action { get; init; } = string.Empty;

    public string EntityType { get; init; } = string.Empty;

    public ulong EntityId { get; init; }

    public string? Metadata { get; init; }

    public DateTime CreatedAt { get; init; }
}
