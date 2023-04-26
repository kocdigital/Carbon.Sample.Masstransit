using Carbon.Sample.Masstransit.MessageContracts;
using MassTransit;

namespace Carbon.Sample.Masstransit.Consumers.NotificationConsumers.SmsSender;

public class SmsSenderConsumer : IConsumer<Notification>
{
    private readonly IBus _bus;

    public SmsSenderConsumer(IBus bus)
    {
        _bus = bus;
    }

    public async Task Consume(ConsumeContext<Notification> context)
    {
        var notification = context.Message;

        // Sms Integration logic
        
        await _bus.Publish(new NotificationResult(Sender.Sms,
            $"Recipient:'{notification.Recipient}',Message:{notification.Message}"));
    }
}