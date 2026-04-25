using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class UserLibraryRepository : IUserLibraryRepository
{
    private readonly global::Online_Store_Backend_WebAPI.DB.AppContext _context;

    public UserLibraryRepository(global::Online_Store_Backend_WebAPI.DB.AppContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<UserLibraryVo>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default)
    {
        var items = await _context.UserLibraries
            .AsNoTracking()
            .Where(item => item.UserId == userId)
            .OrderByDescending(item => item.GrantedAt)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }

    public async Task<UserLibraryVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _context.UserLibraries
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        return item?.ToVo();
    }
}
