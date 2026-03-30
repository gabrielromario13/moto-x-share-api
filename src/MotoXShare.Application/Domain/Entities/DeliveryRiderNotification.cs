namespace MotoXShare.Core.Domain.Entities;

public class DeliveryRiderNotification(int orderId, IEnumerable<int> deliveryRidersIds) : BaseEntity
{
    public int OrderId { get; set; } = orderId;
    public IEnumerable<int> DeliveryRidersIds { get; set; } = deliveryRidersIds;

    public virtual Order Order { get; set; }
}