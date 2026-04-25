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

    public async Task<IReadOnlyList<GameVo>> GetCatalogAsync(ulong? publisherId = null, string? status = null, CancellationToken cancellationToken = default)
    {
        var query = _context.Games
            .AsNoTracking()
            .AsQueryable();

        if (publisherId.HasValue)
        {
            query = query.Where(item => item.PublisherId == publisherId.Value);
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(item => item.Status == status);
        }

        var items = await query
            .OrderBy(item => item.Name)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<GameVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _context.Games
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        return item?.ToVo();
    }

    public async Task<IReadOnlyList<GameVo>> GetByTagAsync(string tagSlug, CancellationToken cancellationToken = default)
    {
        var items = await _context.Games
            .AsNoTracking()
            .Where(item => item.Tags.Any(tag => tag.Slug == tagSlug))
            .OrderBy(item => item.Name)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }
}
