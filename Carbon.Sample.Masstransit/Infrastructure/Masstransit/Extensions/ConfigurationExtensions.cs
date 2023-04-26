using Carbon.Sample.Masstransit.MessageContracts;
using MassTransit.RabbitMqTransport;
using RabbitMQ.Client;

namespace Carbon.Sample.Masstransit.Infrastructure.Masstransit.Extensions;

public static class ConfigurationExtensions
{
    public static void ConfigureMessageTopology(this IRabbitMqBusFactoryConfigurator configurator)
    {
        configurator.Publish<Notification>(x => { x.ExchangeType = ExchangeType.Direct; });
    }
}