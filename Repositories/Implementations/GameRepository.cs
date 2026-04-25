using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class GameRepository : IGameRepository
{
    private readonly global::Online_Store_Backend_WebAPI.DB.AppContext _context;

    public GameRepository(global::Online_Store_Backend_WebAPI.DB.AppContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<GameVo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var games = await _context.Games
            .AsNoTracking()
            .OrderBy(game => game.Name)
            .Take(20)
            .ToListAsync(cancellationToken);

        return games
            .Select(c => c.ToVo())
            .ToList();
    }
}
