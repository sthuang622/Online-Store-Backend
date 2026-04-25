using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Services.Abstractions;

namespace Online_Store_Backend_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _service;

    public ReviewsController(IReviewService service)
    {
        _service = service;
    }

    [HttpGet("product/{productId}")]
    public async Task<ActionResult<IReadOnlyList<ReviewDto>>> GetByProductId(ulong productId, CancellationToken cancellationToken)
    {
        var items = await _service.GetByProductIdAsync(productId, cancellationToken);
        return Ok(items);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IReadOnlyList<ReviewDto>>> GetByUserId(ulong userId, CancellationToken cancellationToken)
    {
        var items = await _service.GetByUserIdAsync(userId, cancellationToken);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDto>> GetById(ulong id, CancellationToken cancellationToken)
    {
        var item = await _service.GetByIdAsync(id, cancellationToken);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }
}
