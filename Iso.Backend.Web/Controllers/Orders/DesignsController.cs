using Iso.Backend.Application.DTO.Items;
using Iso.Backend.Application.Services.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iso.Backend.Web.Controllers.Orders;

[Route("api/v1/[controller]")]
[ApiController]
public class DesignsController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IDesignsService _designsService;

    public DesignsController(ILogger<DesignsController> logger, IDesignsService designsService)
    {
        _logger = logger;
        _designsService = designsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDesigns()
    {
        try
        {
            var designs = await _designsService.GetDesigns();
            return Ok(designs);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al obtener los diseños: {ex.Message}");
            return Problem(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDesign([FromRoute] Guid id)
    {
        try
        {
            var design = await _designsService.GetDesign(id);
            return Ok(design);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al obtener el diseño: {ex.Message}");
            return Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DesignCreateDTO designCreateDTO)
    {
        try
        {
            var design = await _designsService.CreateDesign(designCreateDTO);
            return Ok(design);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al crear el diseño: {ex.Message}");
            return Problem(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] DesignCreateDTO designCreateDTO)
    {
        try
        {
            var design = await _designsService.UpdateDesign(id, designCreateDTO);
            return Ok(design);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar el diseño: {ex.Message}");
            return Problem(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var design = await _designsService.DeleteDesign(id);
        return Ok(design);
    }
}