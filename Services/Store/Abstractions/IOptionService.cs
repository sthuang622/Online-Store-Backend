using Online_Store_Backend_WebAPI.Models.DTOs;

namespace Online_Store_Backend_WebAPI.Services.Store.Abstractions;

public interface IOptionService
{
    Task<Dictionary<string, IReadOnlyList<OptionKindDto>>> GetOptionMapAsync(CancellationToken cancellationToken = default);
}
