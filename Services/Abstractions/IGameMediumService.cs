using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IGameMediumService
{
    Task<IReadOnlyList<GameMediumDto>> GetByGameIdAsync(ulong gameId, CancellationToken cancellationToken = default);

    Task<GameMediumDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
