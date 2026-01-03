using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using WeatherService.Core.Interfaces;

namespace WeatherService.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly QueueClient _queueClient;

    public OrderService(IConfiguration configuration)
    {
        // For demo purposes, we default to development storage if not configured
        var connectionString = configuration["AzureWebJobsStorage"] ?? "UseDevelopmentStorage=true";
        _queueClient = new QueueClient(connectionString, "orders-queue");
    }

    public async Task PlaceOrderAsync(string orderId)
    {
        await _queueClient.CreateIfNotExistsAsync();
        
        if (_queueClient.Exists())
        {
            var message = $"Order placed at {DateTime.UtcNow}: {orderId}";
            await _queueClient.SendMessageAsync(Base64Encode(message));
        }
    }

    private static string Base64Encode(string plainText) 
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
}
