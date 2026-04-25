using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Services.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Services.Implementations;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _repository;

    public ReviewService(IReviewRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ReviewDto>> GetByProductIdAsync(ulong productId, CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetByProductIdAsync(productId, cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }

    public async Task<IReadOnlyList<ReviewDto>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetByUserIdAsync(userId, cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }

    public async Task<ReviewDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdAsync(id, cancellationToken);
        return item?.ToDto();
    }
}
