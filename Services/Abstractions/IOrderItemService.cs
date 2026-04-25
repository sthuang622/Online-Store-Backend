using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IOrderItemService
{
    Task<IReadOnlyList<OrderItemDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<OrderItemDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
