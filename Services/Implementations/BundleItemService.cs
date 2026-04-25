using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Services.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Services.Implementations;

public class BundleItemService : IBundleItemService
{
    private readonly IBundleItemRepository _repository;

    public BundleItemService(IBundleItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<BundleItemDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetAllAsync(cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }

    public async Task<BundleItemDto?> GetByIdsAsync(ulong bundleProductId, ulong itemProductId, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdsAsync(bundleProductId, itemProductId, cancellationToken);
        return item?.ToDto();
    }
}
