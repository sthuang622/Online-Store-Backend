using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IOrderItemRepository
{
    Task<IReadOnlyList<OrderItemVo>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<OrderItemVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
