using Carbon.Sample.Masstransit.Dtos.Notification;
using Carbon.Sample.Masstransit.Infrastructure.Masstransit.Constants;
using Carbon.Sample.Masstransit.MessageContracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Carbon.Sample.Masstransit.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class NotificationSenderController : ControllerBase
{
    private readonly IBus _bus;

    public NotificationSenderController(IBus bus)
    {
        _bus = bus;
    }

    /// <summary>
    /// SendEmail
    /// </summary>
    /// <param name="notificationDto"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("SendEmail")]
    public async Task<IActionResult> SendEmail([FromBody] SendNotificationDto notificationDto)
    {
        // Send Message Using Payload Object
        var endpoint = await _bus.GetPublishSendEndpoint<Notification>();
        await endpoint.Send(
            new Notification(notificationDto.Recipient, notificationDto.Message),
            x => x.SetRoutingKey(RoutingKey.EmailRoutingKey));

        return Ok();
    }

    /// <summary>
    /// SendSms
    /// </summary>
    /// <param name="notificationDto"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("SendSms")]
    public async Task<IActionResult> SendSms([FromBody] SendNotificationDto notificationDto)
    {
        // Send Message Using Full Uri
        var endpoint = await _bus.GetSendEndpoint(
            new Uri("rabbitmq://127.0.0.1:0/Carbon.Sample.Masstransit.MessageContracts:Notification?type=direct"));

        await endpoint.Send(
            new Notification(notificationDto.Recipient, notificationDto.Message),
            x => x.SetRoutingKey(RoutingKey.SmsRoutingKey));

        return Ok();
    }
}