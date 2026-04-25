using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Services.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Services.Implementations;

public class WishlistService : IWishlistService
{
    private readonly IWishlistRepository _repository;

    public WishlistService(IWishlistRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<WishlistDto>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetByUserIdAsync(userId, cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }

    public async Task<WishlistDto?> GetByIdsAsync(ulong userId, ulong productId, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdsAsync(userId, productId, cancellationToken);
        return item?.ToDto();
    }
}
