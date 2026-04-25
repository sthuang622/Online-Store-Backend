using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Services.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ProductDto>> GetByGameIdAsync(ulong gameId, CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetByGameIdAsync(gameId, cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }

    public async Task<IReadOnlyList<ProductDto>> GetByTypeAsync(string type, CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetByTypeAsync(type, cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }

    public async Task<ProductDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdAsync(id, cancellationToken);
        return item?.ToDto();
    }
}
