using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IWishlistRepository
{
    Task<IReadOnlyList<WishlistVo>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default);

    Task<WishlistVo?> GetByIdsAsync(ulong userId, ulong productId, CancellationToken cancellationToken = default);
}
