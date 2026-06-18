using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;
using Online_Store_Backend_WebAPI.DB;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class PublisherRepository : IPublisherRepository
{
    private readonly AppDBContext _context;

    public PublisherRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<PublisherVo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _context.Publishers
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<PublisherVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _context.Publishers
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        return item?.ToVo();
    }
}
