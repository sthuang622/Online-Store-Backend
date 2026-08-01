using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Repositories.Abstractions;

public interface IOptionRepository
{
    Task<IReadOnlyList<OptionVo>> GetAllAsync(CancellationToken cancellationToken = default);
}
