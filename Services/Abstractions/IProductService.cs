using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Abstractions;

public interface IProductService
{
    Task<IReadOnlyList<ProductDto>> GetByGameIdAsync(ulong gameId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ProductDto>> GetByTypeAsync(string type, CancellationToken cancellationToken = default);

    Task<ProductDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);
}
