using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IGameRepository
{
    Task<IReadOnlyList<GameVo>> GetCatalogAsync(ulong? publisherId = null, string? status = null, CancellationToken cancellationToken = default);

    Task<GameVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<GameVo>> GetByTagAsync(string tagSlug, CancellationToken cancellationToken = default);
}
