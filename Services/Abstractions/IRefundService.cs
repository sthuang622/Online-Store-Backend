using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IRefundService
{
    Task<IReadOnlyList<RefundDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<RefundDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
