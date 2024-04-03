namespace MotoXShare.Domain.Notification;

public sealed class Notification
{
    public string Detail { get; private set; }
    public string Error { get; private set; }
    public string Type { get; private set; } = string.Empty;

    public Notification(string detail, string error)
    {
        Detail = detail;
        Error = error;
    }

    public Notification(string detail, string error, string type)
    {
        Detail = detail;
        Error = error;
        Type = type;
    }
}