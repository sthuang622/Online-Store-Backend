using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.DB;
using Online_Store_Backend_WebAPI.Models.VOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Repositories.Implementations;

public class OptionRepository : IOptionRepository
{
    private readonly AppDBContext _context;

    public OptionRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<OptionVo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _context.OptionItems
            .AsNoTracking()
            .OrderBy(item => item.CodeId)
            .ThenBy(item => item.CodeKind)
            .ToListAsync(cancellationToken);

        return items
            .Select(item => item.ToVo())
            .ToList();
    }
}
