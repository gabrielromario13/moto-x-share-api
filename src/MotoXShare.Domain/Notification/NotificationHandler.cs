using MotoXShare.Domain.Base;

namespace MotoXShare.Domain.Notification;

public class NotificationHandler
{
    private readonly List<Notification> _notifications;

    public NotificationHandler() =>
        _notifications = [];

    public virtual void Add(Notification notification) =>
       _notifications.Add(notification);

    public virtual void AddNotifications(IEnumerable<Notification> notifications) =>
        _notifications.AddRange(notifications);

    public virtual IEnumerable<Notification> Get() =>
       _notifications;

    public virtual bool HasNotification() =>
        _notifications.Count > 0;

    public virtual ErrorsResponse GetAllErrorsResponse(string instance, string traceId)
    {
        if (_notifications.Count == 0)
            return null;

        var errors = new List<ErrorsResponseDetail>(_notifications.Count);

        foreach (var notification in _notifications)
            errors.Add(new(notification.Type, notification.Error, notification.Detail));

        return new(instance, traceId, errors);
    }
}