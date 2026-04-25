using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Services.Abstractions;

namespace Online_Store_Backend_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartItemsController : ControllerBase
{
    private readonly ICartItemService _service;

    public CartItemsController(ICartItemService service)
    {
        _service = service;
    }

    [HttpGet("cart/{cartId}")]
    public async Task<ActionResult<IReadOnlyList<CartItemDto>>> GetByCartId(ulong cartId, CancellationToken cancellationToken)
    {
        var items = await _service.GetByCartIdAsync(cartId, cancellationToken);
        return Ok(items);
    }

    [HttpGet("{cartId}/{productId}")]
    public async Task<ActionResult<CartItemDto>> GetByIds(ulong cartId, ulong productId, CancellationToken cancellationToken)
    {
        var item = await _service.GetByIdsAsync(cartId, productId, cancellationToken);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }
}
