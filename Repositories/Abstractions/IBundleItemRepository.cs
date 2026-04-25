using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IBundleItemRepository
{
    Task<IReadOnlyList<BundleItemVo>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<BundleItemVo?> GetByIdsAsync(ulong bundleProductId, ulong itemProductId, CancellationToken cancellationToken = default);
}
