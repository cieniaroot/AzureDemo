using Microsoft.AspNetCore.Mvc;
using WeatherService.Core.Interfaces;

namespace WeatherService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder()
    {
        var orderId = Guid.NewGuid().ToString();
        await _orderService.PlaceOrderAsync(orderId);
        return Ok(new { Message = "Order placed successfully", OrderId = orderId });
    }
}
