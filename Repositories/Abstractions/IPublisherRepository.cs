using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IPublisherRepository
{
    Task<IReadOnlyList<PublisherVo>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<PublisherVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
