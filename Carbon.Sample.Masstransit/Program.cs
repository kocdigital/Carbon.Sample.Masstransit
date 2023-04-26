using System.Reflection;
using Carbon.MassTransit;
using Carbon.Sample.Masstransit.Infrastructure.Masstransit.Extensions;
using Carbon.WebApplication;
using MassTransit;

Console.Title = "CARBON_SAMPLE_MASSTRANSIT";
var builder = WebApplication.CreateBuilder(args);
builder.AddCarbonServices((services) =>
{
    services.AddMassTransitBus(config =>
    {
        config.SetKebabCaseEndpointNameFormatter();

        var entryAssembly = Assembly.GetEntryAssembly();
        config.AddConsumers(entryAssembly);
        config.AddRabbitMqBus(builder.Configuration, (provider, busFactoryConfig) =>
        {
            busFactoryConfig.ConfigureMessageTopology();
            
            var ctx = provider.GetService<IBusRegistrationContext>();
            busFactoryConfig.ConfigureEndpoints(ctx);
        });
    });
    
    return services;
});
var application = builder.Build();
application.AddCarbonApplication((app) =>
{
    app.UseHsts();
    app.UseHttpsRedirection();

    return app;
});
application.Run();