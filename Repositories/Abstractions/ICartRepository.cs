using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface ICartRepository
{
    Task<CartVo?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);

    Task<CartVo?> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default);
}
