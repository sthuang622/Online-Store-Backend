using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface ICartService
{
    Task<CartDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);

    Task<CartDto?> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default);
}
