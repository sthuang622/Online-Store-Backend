using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IPublisherMembershipService
{
    Task<IReadOnlyList<PublisherMembershipDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<PublisherMembershipDto?> GetByIdsAsync(ulong publisherId, ulong userId, CancellationToken cancellationToken = default);
}
