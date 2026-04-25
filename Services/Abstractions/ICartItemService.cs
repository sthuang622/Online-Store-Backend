using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface ICartItemService
{
    Task<IReadOnlyList<CartItemDto>> GetByCartIdAsync(ulong cartId, CancellationToken cancellationToken = default);

    Task<CartItemDto?> GetByIdsAsync(ulong cartId, ulong productId, CancellationToken cancellationToken = default);
}
