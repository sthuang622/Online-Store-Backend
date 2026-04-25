using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IOrderService
{
    Task<IReadOnlyList<OrderDto>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default);

    Task<OrderDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
