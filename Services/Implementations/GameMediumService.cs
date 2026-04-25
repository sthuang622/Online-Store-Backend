using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Services.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Services.Implementations;

public class GameMediumService : IGameMediumService
{
    private readonly IGameMediumRepository _repository;

    public GameMediumService(IGameMediumRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<GameMediumDto>> GetByGameIdAsync(ulong gameId, CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetByGameIdAsync(gameId, cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }

    public async Task<GameMediumDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdAsync(id, cancellationToken);
        return item?.ToDto();
    }
}
