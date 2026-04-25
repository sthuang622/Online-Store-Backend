using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Services.Abstractions;

namespace Online_Store_Backend_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _service;

    public GamesController(IGameService service)
    {
        _service = service;
    }

    [HttpGet("catalog")]
    public async Task<ActionResult<IReadOnlyList<GameDto>>> GetCatalog([FromQuery] ulong? publisherId, [FromQuery] string? status, CancellationToken cancellationToken)
    {
        var items = await _service.GetCatalogAsync(publisherId, status, cancellationToken);
        return Ok(items);
    }

    [HttpGet("tag/{tagSlug}")]
    public async Task<ActionResult<IReadOnlyList<GameDto>>> GetByTag(string tagSlug, CancellationToken cancellationToken)
    {
        var items = await _service.GetByTagAsync(tagSlug, cancellationToken);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameDto>> GetById(ulong id, CancellationToken cancellationToken)
    {
        var item = await _service.GetByIdAsync(id, cancellationToken);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }
}
