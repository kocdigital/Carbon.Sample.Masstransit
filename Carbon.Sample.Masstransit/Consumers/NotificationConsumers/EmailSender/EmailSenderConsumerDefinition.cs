using Carbon.Sample.Masstransit.Infrastructure.Masstransit.Constants;
using Carbon.Sample.Masstransit.MessageContracts;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using MassTransit.RabbitMqTransport;
using RabbitMQ.Client;

namespace Carbon.Sample.Masstransit.Consumers.NotificationConsumers.EmailSender;

public class EmailSenderConsumerDefinition : ConsumerDefinition<EmailSenderConsumer>
{
    public EmailSenderConsumerDefinition()
    {
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<EmailSenderConsumer> consumerConfigurator)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.Bind<Notification>(x =>
            {
                x.RoutingKey = RoutingKey.EmailRoutingKey;
                x.ExchangeType = ExchangeType.Direct;
            });
        }
    }
}