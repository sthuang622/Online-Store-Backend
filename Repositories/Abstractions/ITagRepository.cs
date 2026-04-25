using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface ITagRepository
{
    Task<IReadOnlyList<TagVo>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<TagVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
