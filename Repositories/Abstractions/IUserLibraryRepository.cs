using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IUserLibraryRepository
{
    Task<IReadOnlyList<UserLibraryVo>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default);

    Task<UserLibraryVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
