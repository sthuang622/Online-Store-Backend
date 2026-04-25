using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Services.Abstractions;

namespace Online_Store_Backend_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BundleItemsController : ControllerBase
{
    private readonly IBundleItemService _service;

    public BundleItemsController(IBundleItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<BundleItemDto>>> GetAll(CancellationToken cancellationToken)
    {
        var items = await _service.GetAllAsync(cancellationToken);
        return Ok(items);
    }

    [HttpGet("{bundleProductId}/{itemProductId}")]
    public async Task<ActionResult<BundleItemDto>> GetByIds(ulong bundleProductId, ulong itemProductId, CancellationToken cancellationToken)
    {
        var item = await _service.GetByIdsAsync(bundleProductId, itemProductId, cancellationToken);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }
}
