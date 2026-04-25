using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Services.Abstractions;

namespace Online_Store_Backend_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublisherMembershipsController : ControllerBase
{
    private readonly IPublisherMembershipService _service;

    public PublisherMembershipsController(IPublisherMembershipService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PublisherMembershipDto>>> GetAll(CancellationToken cancellationToken)
    {
        var items = await _service.GetAllAsync(cancellationToken);
        return Ok(items);
    }

    [HttpGet("{publisherId}/{userId}")]
    public async Task<ActionResult<PublisherMembershipDto>> GetByIds(ulong publisherId, ulong userId, CancellationToken cancellationToken)
    {
        var item = await _service.GetByIdsAsync(publisherId, userId, cancellationToken);

        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }
}
