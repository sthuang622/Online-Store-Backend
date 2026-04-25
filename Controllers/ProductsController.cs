using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Services.Abstractions;

namespace Online_Store_Backend_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet("game/{gameId}")]
    public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetByGameId(ulong gameId, CancellationToken cancellationToken)
    {
        var items = await _service.GetByGameIdAsync(gameId, cancellationToken);
        return Ok(items);
    }

    [HttpGet("type/{type}")]
    public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetByType(string type, CancellationToken cancellationToken)
    {
        var items = await _service.GetByTypeAsync(type, cancellationToken);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(ulong id, CancellationToken cancellationToken)
    {
        var item = await _service.GetByIdAsync(id, cancellationToken);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }
}
