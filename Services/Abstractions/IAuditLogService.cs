using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IAuditLogService
{
    Task<IReadOnlyList<AuditLogDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<AuditLogDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
