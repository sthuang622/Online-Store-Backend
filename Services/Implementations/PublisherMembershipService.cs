using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Services.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Services.Implementations;

public class PublisherMembershipService : IPublisherMembershipService
{
    private readonly IPublisherMembershipRepository _repository;

    public PublisherMembershipService(IPublisherMembershipRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<PublisherMembershipDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetAllAsync(cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }

    public async Task<PublisherMembershipDto?> GetByIdsAsync(ulong publisherId, ulong userId, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdsAsync(publisherId, userId, cancellationToken);
        return item?.ToDto();
    }
}
