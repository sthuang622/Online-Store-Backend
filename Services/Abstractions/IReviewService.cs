using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IReviewService
{
    Task<IReadOnlyList<ReviewDto>> GetByProductIdAsync(ulong productId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ReviewDto>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default);

    Task<ReviewDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
