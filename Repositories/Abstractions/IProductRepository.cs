using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IProductRepository
{
    Task<IReadOnlyList<ProductVo>> GetByGameIdAsync(ulong gameId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ProductVo>> GetByTypeAsync(string type, CancellationToken cancellationToken = default);

    Task<ProductVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
