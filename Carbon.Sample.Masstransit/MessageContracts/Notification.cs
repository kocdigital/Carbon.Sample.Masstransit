namespace Carbon.Sample.Masstransit.MessageContracts;

public class Notification
{
    public Notification(string recipient, string message)
    {
        Recipient = recipient;
        Message = message;
    }

    public string Recipient { get; set; }
    public string Message { get; set; }
}