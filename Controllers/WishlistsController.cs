using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Services.Abstractions;

namespace Online_Store_Backend_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WishlistsController : ControllerBase
{
    private readonly IWishlistService _service;

    public WishlistsController(IWishlistService service)
    {
        _service = service;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IReadOnlyList<WishlistDto>>> GetByUserId(ulong userId, CancellationToken cancellationToken)
    {
        var items = await _service.GetByUserIdAsync(userId, cancellationToken);
        return Ok(items);
    }

    [HttpGet("user/{userId}/product/{productId}")]
    public async Task<ActionResult<WishlistDto>> GetByIds(ulong userId, ulong productId, CancellationToken cancellationToken)
    {
        var item = await _service.GetByIdsAsync(userId, productId, cancellationToken);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }
}
