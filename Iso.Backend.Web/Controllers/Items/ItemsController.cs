using Iso.Backend.Application.DTO.Items;
using Iso.Backend.Application.Services.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iso.Backend.Web.Controllers.Items;

[Route("api/v1/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IItemsService _itemService;

    public ItemsController(ILogger<ItemsController> logger, IItemsService itemService)
    {
        _logger = logger;
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetItems(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string orderBy = "Name",
        [FromQuery] string orderDirection = "asc",
        [FromQuery] string search = null,
        [FromQuery] Guid? categoryId = null)
    {
        try
        {
            var items = await _itemService.GetItems(page, pageSize, orderBy, orderDirection, search, categoryId);
            return Ok(items);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al obtener los items: {ex.Message}");
            return Problem(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemById([FromRoute] Guid id)
    {
        try
        {
            var result = await _itemService.GetItem(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al obtener el item: {ex.Message}");
            return Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ItemCreateDTO itemCreateDTO)
    {
        try
        {
            var result = await _itemService.CreateItem(itemCreateDTO);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al crear el item: {ex.Message}");
            return Problem(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] ItemCreateDTO itemUpdateDTO)
    {
        try
        {
            var result = await _itemService.UpdateItem(id, itemUpdateDTO);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al actualizar el item: {ex.Message}");
            return Problem(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _itemService.DeleteItem(id);
        return Ok(result);
    }
}