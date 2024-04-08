using Microsoft.AspNetCore.Mvc;

namespace Iso.Backend.Web.Controllers.Orders;

[Route("api/v1/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    //Pon filtros por query string
    [HttpGet]
    public IActionResult GetItems()
    {
        return Ok("Items");
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok("Items");
    }
}