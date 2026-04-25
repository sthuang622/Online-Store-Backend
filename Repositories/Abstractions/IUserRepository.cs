using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IUserRepository
{
    Task<IReadOnlyList<UserVo>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<UserVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
