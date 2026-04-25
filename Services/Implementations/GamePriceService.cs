using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Services.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Services.Implementations;

public class GamePriceService : IGamePriceService
{
    private readonly IGamePriceRepository _repository;

    public GamePriceService(IGamePriceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<GamePriceDto>> GetByGameIdAsync(ulong gameId, CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetByGameIdAsync(gameId, cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }

    public async Task<GamePriceDto?> GetByGameAndRegionAsync(ulong gameId, string regionCode, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByGameAndRegionAsync(gameId, regionCode, cancellationToken);
        return item?.ToDto();
    }

    public async Task<GamePriceDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdAsync(id, cancellationToken);
        return item?.ToDto();
    }
}
