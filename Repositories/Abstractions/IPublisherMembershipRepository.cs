using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IPublisherMembershipRepository
{
    Task<IReadOnlyList<PublisherMembershipVo>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<PublisherMembershipVo?> GetByIdsAsync(ulong publisherId, ulong userId, CancellationToken cancellationToken = default);
}
