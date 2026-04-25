using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class AuditLogMapper
{
    public static AuditLogVo ToVo(this AuditLog AuditLog)
    {
        return new AuditLogVo
        {
            Id = AuditLog.Id,
            ActorUserId = AuditLog.ActorUserId,
            Action = AuditLog.Action,
            EntityType = AuditLog.EntityType,
            EntityId = AuditLog.EntityId,
            Metadata = AuditLog.Metadata,
            CreatedAt = AuditLog.CreatedAt
        };
    }

    public static AuditLog ToDbObject(this AuditLogVo AuditLogVo)
    {
        return new AuditLog
        {
            Id = AuditLogVo.Id,
            ActorUserId = AuditLogVo.ActorUserId,
            Action = AuditLogVo.Action,
            EntityType = AuditLogVo.EntityType,
            EntityId = AuditLogVo.EntityId,
            Metadata = AuditLogVo.Metadata,
            CreatedAt = AuditLogVo.CreatedAt
        };
    }

    public static AuditLogDto ToDto(this AuditLogVo AuditLogVo)
    {
        return new AuditLogDto
        {
            Id = AuditLogVo.Id,
            ActorUserId = AuditLogVo.ActorUserId,
            Action = AuditLogVo.Action,
            EntityType = AuditLogVo.EntityType,
            EntityId = AuditLogVo.EntityId,
            Metadata = AuditLogVo.Metadata,
            CreatedAt = AuditLogVo.CreatedAt
        };
    }

    public static AuditLogVo ToVo(this AuditLogDto AuditLogDto)
    {
        return new AuditLogVo
        {
            Id = AuditLogDto.Id,
            ActorUserId = AuditLogDto.ActorUserId,
            Action = AuditLogDto.Action,
            EntityType = AuditLogDto.EntityType,
            EntityId = AuditLogDto.EntityId,
            Metadata = AuditLogDto.Metadata,
            CreatedAt = AuditLogDto.CreatedAt
        };
    }
}
