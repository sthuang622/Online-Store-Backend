using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;
using Online_Store_Backend_WebAPI.DB;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class GameMediumRepository : IGameMediumRepository
{
    private readonly AppDBContext _context;

    public GameMediumRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<GameMediumVo>> GetByGameIdAsync(ulong gameId, CancellationToken cancellationToken = default)
    {
        var items = await _context.GameMedia
            .AsNoTracking()
            .Where(item => item.GameId == gameId)
            .OrderBy(item => item.SortOrder)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<GameMediumVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _context.GameMedia
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        return item?.ToVo();
    }
}
