using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface ITagService
{
    Task<IReadOnlyList<TagDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<TagDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
