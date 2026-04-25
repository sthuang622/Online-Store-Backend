using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class CartItemRepository : ICartItemRepository
{
    private readonly global::Online_Store_Backend_WebAPI.DB.AppContext _context;

    public CartItemRepository(global::Online_Store_Backend_WebAPI.DB.AppContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<CartItemVo>> GetByCartIdAsync(ulong cartId, CancellationToken cancellationToken = default)
    {
        var items = await _context.CartItems
            .AsNoTracking()
            .Where(item => item.CartId == cartId)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<CartItemVo?> GetByIdsAsync(ulong cartId, ulong productId, CancellationToken cancellationToken = default)
    {
        var item = await _context.CartItems
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.CartId == cartId && item.ProductId == productId, cancellationToken);

        return item?.ToVo();
    }
}
