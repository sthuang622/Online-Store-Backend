using System;
using System.Collections.Generic;

namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class AuditLog
{
    public ulong Id { get; set; }

    public ulong? ActorUserId { get; set; }

    public string Action { get; set; } = null!;

    public string EntityType { get; set; } = null!;

    public ulong EntityId { get; set; }

    public string? Metadata { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User? ActorUser { get; set; }
}
