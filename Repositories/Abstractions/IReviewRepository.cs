using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IReviewRepository
{
    Task<IReadOnlyList<ReviewVo>> GetByProductIdAsync(ulong productId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ReviewVo>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default);

    Task<ReviewVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
