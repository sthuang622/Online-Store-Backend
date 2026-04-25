using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class WishlistRepository : IWishlistRepository
{
    private readonly global::Online_Store_Backend_WebAPI.DB.AppContext _context;

    public WishlistRepository(global::Online_Store_Backend_WebAPI.DB.AppContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<WishlistVo>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default)
    {
        var items = await _context.Wishlists
            .AsNoTracking()
            .Where(item => item.UserId == userId)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<WishlistVo?> GetByIdsAsync(ulong userId, ulong productId, CancellationToken cancellationToken = default)
    {
        var item = await _context.Wishlists
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.UserId == userId && item.ProductId == productId, cancellationToken);

        return item?.ToVo();
    }
}
