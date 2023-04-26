using Carbon.Sample.Masstransit.MessageContracts;
using MassTransit;

namespace Carbon.Sample.Masstransit.Consumers.NotificationConsumers.Result;

public class NotificationResultConsumer : IConsumer<NotificationResult>
{
    private readonly ILogger<NotificationResultConsumer> _logger;

    public NotificationResultConsumer(ILogger<NotificationResultConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<NotificationResult> context)
    {
        var notificationResult = context.Message;
        _logger.LogError(
            "{Sender} sent. Detail:{Message}",
            notificationResult.Sender, notificationResult.Message);

        await Task.CompletedTask;
    }
}