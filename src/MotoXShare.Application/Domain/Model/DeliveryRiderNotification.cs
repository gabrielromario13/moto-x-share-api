namespace MotoXShare.Application.Domain.Model;

public class DeliveryRiderNotification : BaseEntity
{
    public Guid OrderId { get; set; }
    public IList<Guid> DeliveryRidersIds { get; set; }

    public virtual Order Order { get; set; }
}