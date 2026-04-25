using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IOrderRepository
{
    Task<IReadOnlyList<OrderVo>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default);

    Task<OrderVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
