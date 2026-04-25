using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class AuditLogRepository : IAuditLogRepository
{
    private readonly global::Online_Store_Backend_WebAPI.DB.AppContext _context;

    public AuditLogRepository(global::Online_Store_Backend_WebAPI.DB.AppContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<AuditLogVo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _context.AuditLogs
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<AuditLogVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _context.AuditLogs
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        return item?.ToVo();
    }
}
