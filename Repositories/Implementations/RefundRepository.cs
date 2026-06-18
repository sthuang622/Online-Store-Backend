using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;
using Online_Store_Backend_WebAPI.DB;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class RefundRepository : IRefundRepository
{
    private readonly AppDBContext _context;

    public RefundRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<RefundVo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _context.Refunds
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<RefundVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _context.Refunds
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        return item?.ToVo();
    }
}
