using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface ICartItemRepository
{
    Task<IReadOnlyList<CartItemVo>> GetByCartIdAsync(ulong cartId, CancellationToken cancellationToken = default);

    Task<CartItemVo?> GetByIdsAsync(ulong cartId, ulong productId, CancellationToken cancellationToken = default);
}
