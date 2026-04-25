using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IWishlistService
{
    Task<IReadOnlyList<WishlistDto>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default);

    Task<WishlistDto?> GetByIdsAsync(ulong userId, ulong productId, CancellationToken cancellationToken = default);
}
