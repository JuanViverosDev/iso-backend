using Iso.Backend.Application.DTO.Items;
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

    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderCreateDTO orderCreateDTO)
    {
        try
        {
            var result = await _ordersService.CreateOrder(orderCreateDTO);
            return Ok(result);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrder(Guid orderId)
    {
        try
        {
            var result = await _ordersService.GetOrder(orderId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        try
        {
            var result = await _ordersService.GetOrders();
            return Ok(result);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrder(Guid orderId, OrderCreateDTO orderCreateDTO)
    {
        try
        {
            var result = await _ordersService.UpdateOrder(orderId, orderCreateDTO);
            return Ok(result);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpDelete("{orderId}")]
    public async Task<IActionResult> DeleteOrder(Guid orderId)
    {
        try
        {
            var result = await _ordersService.DeleteOrder(orderId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpPost("Detail")]
    public async Task<IActionResult> CreateOrderDetail(OrderDetailCreateDTO orderDetailCreateDTO)
    {
        try
        {
            var result = await _ordersService.CreateOrderDetail(orderDetailCreateDTO);
            return Ok(result);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
}