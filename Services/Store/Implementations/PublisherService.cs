using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Services.Store.Abstractions;
using Online_Store_Backend_WebAPI.Util.Mappers;

namespace Online_Store_Backend_WebAPI.Services.Store.Implementations;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _repository;
    private readonly IPublisherMembershipRepository _publisherMembershipRepository;
    private readonly IGameRepository _gameRepository;

    public PublisherService(
        IPublisherRepository repository,
        IPublisherMembershipRepository publisherMembershipRepository,
        IGameRepository gameRepository)
    {
        _repository = repository;
        _publisherMembershipRepository = publisherMembershipRepository;
        _gameRepository = gameRepository;
    }

    public async Task<IReadOnlyList<PublisherDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _repository.GetAllAsync(cancellationToken);

        return items
            .Select(item => item.ToDto())
            .ToList();
    }

    public async Task<PublisherDto?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdAsync(id, cancellationToken);
        return item?.ToDto();
    }

    public async Task<GameDto?> AddGameAsync(ulong publisherId, CreatePublisherGameRequestDto request, CancellationToken cancellationToken = default)
    {
        var membership = await _publisherMembershipRepository.GetByIdsAsync(publisherId, request.UserId, cancellationToken);

        if (membership is null || !CanManagePublisherGames(membership.Role))
        {
            return null;
        }

        var utcNow = DateTime.UtcNow;
        var game = new GameDto
        {
            PublisherId = publisherId,
            Name = request.Name,
            Slug = request.Slug,
            ShortDescription = request.ShortDescription,
            LongDescription = request.LongDescription,
            Status = string.IsNullOrWhiteSpace(request.Status) ? "draft" : request.Status,
            ReleaseDate = request.ReleaseDate,
            CreatedAt = utcNow,
            UpdatedAt = utcNow
        };

        var createdGame = await _gameRepository.CreateAsync(game.ToVo(), cancellationToken);
        return createdGame.ToDto();
    }

    private static bool CanManagePublisherGames(string role)
    {
        return role is "owner" or "admin" or "editor";
    }
}
