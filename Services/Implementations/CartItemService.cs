using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Services.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Services.Implementations;

public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _repository;

    public CartItemService(ICartItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<CartItemDto>> GetByCartIdAsync(ulong cartId, CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetByCartIdAsync(cartId, cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }

    public async Task<CartItemDto?> GetByIdsAsync(ulong cartId, ulong productId, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdsAsync(cartId, productId, cancellationToken);
        return item?.ToDto();
    }
}
