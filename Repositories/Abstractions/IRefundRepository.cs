using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IRefundRepository
{
    Task<IReadOnlyList<RefundVo>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<RefundVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
