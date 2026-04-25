using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class BundleItemRepository : IBundleItemRepository
{
    private readonly global::Online_Store_Backend_WebAPI.DB.AppContext _context;

    public BundleItemRepository(global::Online_Store_Backend_WebAPI.DB.AppContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<BundleItemVo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _context.BundleItems
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<BundleItemVo?> GetByIdsAsync(ulong bundleProductId, ulong itemProductId, CancellationToken cancellationToken = default)
    {
        var item = await _context.BundleItems
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.BundleProductId == bundleProductId && item.ItemProductId == itemProductId, cancellationToken);

        return item?.ToVo();
    }
}
