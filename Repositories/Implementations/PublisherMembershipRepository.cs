using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class PublisherMembershipRepository : IPublisherMembershipRepository
{
    private readonly global::Online_Store_Backend_WebAPI.DB.AppContext _context;

    public PublisherMembershipRepository(global::Online_Store_Backend_WebAPI.DB.AppContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<PublisherMembershipVo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _context.PublisherMemberships
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<PublisherMembershipVo?> GetByIdsAsync(ulong publisherId, ulong userId, CancellationToken cancellationToken = default)
    {
        var item = await _context.PublisherMemberships
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.PublisherId == publisherId && item.UserId == userId, cancellationToken);

        return item?.ToVo();
    }
}
