using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IAuditLogRepository
{
    Task<IReadOnlyList<AuditLogVo>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<AuditLogVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
