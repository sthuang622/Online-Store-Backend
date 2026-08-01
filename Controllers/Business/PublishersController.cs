using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Services.Store.Abstractions;

namespace Online_Store_Backend_WebAPI.Controllers.Business;

[ApiController]
[Route("api/[controller]")]
public class PublishersController : ControllerBase
{
    private readonly IPublisherService _service;

    public PublishersController(IPublisherService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PublisherDto>>> GetAll(CancellationToken cancellationToken)
    {
        var items = await _service.GetAllAsync(cancellationToken);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PublisherDto>> GetById(ulong id, CancellationToken cancellationToken)
    {
        var item = await _service.GetByIdAsync(id, cancellationToken);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost("{publisherId}/games")]
    public async Task<ActionResult<GameDto>> AddGame(ulong publisherId, [FromBody] CreatePublisherGameRequestDto request, CancellationToken cancellationToken)
    {
        var publisher = await _service.GetByIdAsync(publisherId, cancellationToken);

        if (publisher is null)
        {
            return NotFound();
        }

        var game = await _service.AddGameAsync(publisherId, request, cancellationToken);

        if (game is null)
        {
            return Forbid();
        }

        return Created($"/api/games/{game.Id}", game);
    }
}
