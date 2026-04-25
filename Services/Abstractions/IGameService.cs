using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IGameService
{
    Task<IReadOnlyList<GameDto>> GetCatalogAsync(ulong? publisherId = null, string? status = null, CancellationToken cancellationToken = default);

    Task<GameDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<GameDto>> GetByTagAsync(string tagSlug, CancellationToken cancellationToken = default);
}
