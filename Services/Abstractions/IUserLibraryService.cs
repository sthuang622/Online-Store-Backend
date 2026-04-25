using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IUserLibraryService
{
    Task<IReadOnlyList<UserLibraryDto>> GetByUserIdAsync(ulong userId, CancellationToken cancellationToken = default);

    Task<UserLibraryDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
