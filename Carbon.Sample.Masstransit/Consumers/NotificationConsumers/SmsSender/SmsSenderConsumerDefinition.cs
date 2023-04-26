using Carbon.Sample.Masstransit.Infrastructure.Masstransit.Constants;
using Carbon.Sample.Masstransit.MessageContracts;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using MassTransit.RabbitMqTransport;
using RabbitMQ.Client;

namespace Carbon.Sample.Masstransit.Consumers.NotificationConsumers.SmsSender;

public class SmsSenderConsumerDefinition : ConsumerDefinition<SmsSenderConsumer>
{
    public SmsSenderConsumerDefinition()
    {
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SmsSenderConsumer> consumerConfigurator)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.Bind<Notification>(x =>
            {
                x.RoutingKey = RoutingKey.SmsRoutingKey;
                x.ExchangeType = ExchangeType.Direct;
            });
        }
    }
}