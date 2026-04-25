using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Services.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Services.Implementations;

public class GameService : IGameService
{
    private readonly IGameRepository _repository;

    public GameService(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<GameDto>> GetCatalogAsync(ulong? publisherId = null, string? status = null, CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetCatalogAsync(publisherId, status, cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }

    public async Task<GameDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdAsync(id, cancellationToken);
        return item?.ToDto();
    }

    public async Task<IReadOnlyList<GameDto>> GetByTagAsync(string tagSlug, CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetByTagAsync(tagSlug, cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }
}
