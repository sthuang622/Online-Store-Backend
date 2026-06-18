using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.DB;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class CartRepository : ICartRepository
{
    private readonly AppDBContext _context;

    public CartRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<CartVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _context.Carts
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        return item?.ToVo();
    }

    public async Task<CartVo?> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default)
    {
        var item = await _context.Carts
            .AsNoTracking()
            .Where(item => item.UserId == userId)
            .OrderByDescending(item => item.UpdatedAt)
            .FirstOrDefaultAsync(cancellationToken);

        return item?.ToVo();
    }
}
