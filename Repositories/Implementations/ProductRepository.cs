using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;
using Online_Store_Backend_WebAPI.DB;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly AppDBContext _context;

    public ProductRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductVo>> GetByGameIdAsync(ulong gameId, CancellationToken cancellationToken = default)
    {
        var items = await _context.Products
            .AsNoTracking()
            .Where(item => item.GameId == gameId)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<IReadOnlyList<ProductVo>> GetByTypeAsync(string type, CancellationToken cancellationToken = default)
    {
        var items = await _context.Products
            .AsNoTracking()
            .Where(item => item.Type == type)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<ProductVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        return item?.ToVo();
    }
}
