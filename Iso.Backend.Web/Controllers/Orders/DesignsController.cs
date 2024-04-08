using Microsoft.AspNetCore.Mvc;

namespace Iso.Backend.Web.Controllers.Orders;

[Route("api/v1/[controller]")]
[ApiController]
public class DesignsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetDesigns()
    {
        return Ok("Designs");
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok("Designs");
    }
}