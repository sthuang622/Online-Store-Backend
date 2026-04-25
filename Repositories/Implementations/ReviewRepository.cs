using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class ReviewRepository : IReviewRepository
{
    private readonly global::Online_Store_Backend_WebAPI.DB.AppContext _context;

    public ReviewRepository(global::Online_Store_Backend_WebAPI.DB.AppContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ReviewVo>> GetByProductIdAsync(ulong productId, CancellationToken cancellationToken = default)
    {
        var items = await _context.Reviews
            .AsNoTracking()
            .Where(item => item.ProductId == productId)
            .OrderByDescending(item => item.UpdatedAt)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<IReadOnlyList<ReviewVo>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default)
    {
        var items = await _context.Reviews
            .AsNoTracking()
            .Where(item => item.UserId == userId)
            .OrderByDescending(item => item.UpdatedAt)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<ReviewVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _context.Reviews
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        return item?.ToVo();
    }
}
