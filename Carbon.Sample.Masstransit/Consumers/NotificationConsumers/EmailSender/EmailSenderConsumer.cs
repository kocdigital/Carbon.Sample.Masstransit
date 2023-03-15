using Carbon.Sample.Masstransit.MessageContracts;
using MassTransit;

namespace Carbon.Sample.Masstransit.Consumers.NotificationConsumers.EmailSender;

public class EmailSenderConsumer : IConsumer<Notification>
{
    private readonly IBus _bus;

    public EmailSenderConsumer(IBus bus)
    {
        _bus = bus;
    }

    public async Task Consume(ConsumeContext<Notification> context)
    {
        var notification = context.Message;
        
        // Email Integration logic
        
        await _bus.Publish(new NotificationResult(Sender.Email,
            $"Recipient:'{notification.Recipient}',Message:{notification.Message}"));
    }
}