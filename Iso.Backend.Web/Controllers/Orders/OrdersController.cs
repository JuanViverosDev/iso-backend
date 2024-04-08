using Iso.Backend.Application.Services.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iso.Backend.Web.Controllers.Orders;

[Route("api/v1/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrdersService _ordersService;

    public OrdersController(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        try
        {
            return Ok("Orders");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateOrder()
    {
        return Ok("Order");
    }

    [HttpPost("{orderId}")]
    public IActionResult UpdateOrder(Guid orderId)
    {
        return Ok("Order");
    }

    [HttpDelete("{orderId}")]
    public IActionResult DeleteOrder(Guid orderId)
    {
        return Ok("Order");
    }
}