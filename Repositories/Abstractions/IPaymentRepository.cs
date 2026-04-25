using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IPaymentRepository
{
    Task<IReadOnlyList<PaymentVo>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<PaymentVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
