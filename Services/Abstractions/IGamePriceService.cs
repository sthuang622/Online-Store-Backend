using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IGamePriceService
{
    Task<IReadOnlyList<GamePriceDto>> GetByGameIdAsync(ulong gameId, CancellationToken cancellationToken = default);

    Task<GamePriceDto?> GetByGameAndRegionAsync(ulong gameId, string regionCode, CancellationToken cancellationToken = default);

    Task<GamePriceDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
