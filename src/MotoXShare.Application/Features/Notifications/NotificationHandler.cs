using MotoXShare.Application.Domain.Base;

namespace MotoXShare.Application.Features.Notifications;

public class NotificationHandler
{
    private readonly List<Notification> _notifications = [];

    public virtual void Add(Notification notification) =>
       _notifications.Add(notification);

    public virtual bool HasNotification() =>
        _notifications.Count > 0;

    public virtual ErrorsResponse GetAllErrorsResponse(string instance, string traceId)
    {
        if (_notifications.Count == 0)
            return null;

        var errors = new List<ErrorsResponseDetail>(_notifications.Count);
        
        errors.AddRange(_notifications
            .Select(notification => 
                new ErrorsResponseDetail(notification.Error, notification.Detail)));

        return new(instance, traceId, errors);
    }
}