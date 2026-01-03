namespace WeatherService.Core.Interfaces;

public interface IOrderService
{
    Task PlaceOrderAsync(string orderId);
}
