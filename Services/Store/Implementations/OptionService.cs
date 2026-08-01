using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Services.Store.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Services.Store.Implementations;

public class OptionService : IOptionService
{
    private readonly IOptionRepository _repository;

    public OptionService(IOptionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Dictionary<string, IReadOnlyList<OptionKindDto>>> GetOptionMapAsync(CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetAllAsync(cancellationToken);

        return items
            .GroupBy(item => item.CodeId)
            .ToDictionary(
                group => group.Key,
                group => (IReadOnlyList<OptionKindDto>)group
                    .Select(item => item.ToDto())
                    .ToList());
    }
}
