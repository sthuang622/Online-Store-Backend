using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IGameRepository
{
    Task<IReadOnlyList<GameVo>> GetAllAsync(CancellationToken cancellationToken = default);
}
