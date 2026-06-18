using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;
using Online_Store_Backend_WebAPI.DB;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class OrderRepository : IOrderRepository
{
    private readonly AppDBContext _context;

    public OrderRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<OrderVo>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default)
    {
        var items = await _context.Orders
            .AsNoTracking()
            .Where(item => item.UserId == userId)
            .OrderByDescending(item => item.CreatedAt)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<OrderVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        return item?.ToVo();
    }
}
