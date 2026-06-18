using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IUserRepository
{
    Task<IReadOnlyList<UserVo>> GetAllAsync(CancellationToken cancellationToken = default);

    public Task<UserVo> GetByEmail(string email, CancellationToken cancellationToken = default);

    public Task<bool> UpdateEmail(ulong id, string newEmail);

    public Task<bool> UpdatePassword(ulong id, string newPassword);
}
