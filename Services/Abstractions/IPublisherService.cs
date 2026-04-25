using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IPublisherService
{
    Task<IReadOnlyList<PublisherDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<PublisherDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
