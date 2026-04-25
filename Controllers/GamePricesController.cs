using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Services.Abstractions;

namespace Online_Store_Backend_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamePricesController : ControllerBase
{
    private readonly IGamePriceService _service;

    public GamePricesController(IGamePriceService service)
    {
        _service = service;
    }

    [HttpGet("game/{gameId}")]
    public async Task<ActionResult<IReadOnlyList<GamePriceDto>>> GetByGameId(ulong gameId, CancellationToken cancellationToken)
    {
        var items = await _service.GetByGameIdAsync(gameId, cancellationToken);
        return Ok(items);
    }

    [HttpGet("game/{gameId}/region/{regionCode}")]
    public async Task<ActionResult<GamePriceDto>> GetByGameAndRegion(ulong gameId, string regionCode, CancellationToken cancellationToken)
    {
        var item = await _service.GetByGameAndRegionAsync(gameId, regionCode, cancellationToken);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GamePriceDto>> GetById(ulong id, CancellationToken cancellationToken)
    {
        var item = await _service.GetByIdAsync(id, cancellationToken);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }
}
