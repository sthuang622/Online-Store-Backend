using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IGameMediumRepository
{
    Task<IReadOnlyList<GameMediumVo>> GetByGameIdAsync(ulong gameId, CancellationToken cancellationToken = default);

    Task<GameMediumVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
