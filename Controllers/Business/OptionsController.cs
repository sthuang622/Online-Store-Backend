using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Services.Store.Abstractions;

namespace Online_Store_Backend_WebAPI.Controllers.Business;

[ApiController]
[Route("api/[controller]")]
public class OptionsController : ControllerBase
{
    private readonly IOptionService _service;

    public OptionsController(IOptionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<Dictionary<string, IReadOnlyList<OptionKindDto>>>> GetOptionMap(CancellationToken cancellationToken)
    {
        var items = await _service.GetOptionMapAsync(cancellationToken);
        return Ok(items);
    }
}
