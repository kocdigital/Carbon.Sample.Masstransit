namespace Carbon.Sample.Masstransit.MessageContracts;

public class NotificationResult
{
    public NotificationResult(Sender sender, string message)
    {
        Sender = sender;
        Message = message;
    }

    public Sender Sender { get; set; }
    public string Message { get; set; }
}

public enum Sender
{
    Email = 0,
    Sms = 1
}