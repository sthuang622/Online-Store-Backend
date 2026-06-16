using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Store.Abstractions;

public interface IBundleItemService
{
    Task<IReadOnlyList<BundleItemDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<BundleItemDto?> GetByIdsAsync(ulong bundleProductId, ulong itemProductId, CancellationToken cancellationToken = default);
}
