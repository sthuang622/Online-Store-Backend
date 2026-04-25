using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class GamePriceRepository : IGamePriceRepository
{
    private readonly global::Online_Store_Backend_WebAPI.DB.AppContext _context;

    public GamePriceRepository(global::Online_Store_Backend_WebAPI.DB.AppContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<GamePriceVo>> GetByGameIdAsync(ulong gameId, CancellationToken cancellationToken = default)
    {
        var items = await _context.GamePrices
            .AsNoTracking()
            .Where(item => item.GameId == gameId)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<GamePriceVo?> GetByGameAndRegionAsync(ulong gameId, string regionCode, CancellationToken cancellationToken = default)
    {
        var item = await _context.GamePrices
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.GameId == gameId && item.RegionCode == regionCode, cancellationToken);

        return item?.ToVo();
    }

    public async Task<GamePriceVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _context.GamePrices
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        return item?.ToVo();
    }
}
