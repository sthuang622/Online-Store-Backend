using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IGamePriceRepository
{
    Task<IReadOnlyList<GamePriceVo>> GetByGameIdAsync(ulong gameId, CancellationToken cancellationToken = default);

    Task<GamePriceVo?> GetByGameAndRegionAsync(ulong gameId, string regionCode, CancellationToken cancellationToken = default);

    Task<GamePriceVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
