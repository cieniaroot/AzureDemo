using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace OrderProcessor;

public class OrderQueueTrigger
{
    private readonly ILogger<OrderQueueTrigger> _logger;

    public OrderQueueTrigger(ILogger<OrderQueueTrigger> logger)
    {
        _logger = logger;
    }

    [Function("ProcessOrder")]
    public void Run([QueueTrigger("orders-queue", Connection = "AzureWebJobsStorage")] string message)
    {
        _logger.LogInformation($"C# Queue trigger function processed: {message}");
    }
}
