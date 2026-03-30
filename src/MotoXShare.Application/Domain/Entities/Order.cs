using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Domain.Entities;

public class Order(decimal deliveryPrice, OrderStatus status, DateTime createdAt) : BaseEntity
{
    public decimal DeliveryPrice { get; set; } = deliveryPrice;
    public OrderStatus Status { get; set; } = status;
    public DateTime CreatedAt { get; set; } = createdAt;

    public int? DeliveryRiderId { get; set; }
    public virtual DeliveryRider DeliveryRider { get; set; }

    public void Update(int deliveryRiderId, OrderStatus status)
    {
        DeliveryRiderId = !DeliveryRiderId.HasValue ? deliveryRiderId : DeliveryRiderId;
        Status = GetStatus(status);
    }

    private static OrderStatus GetStatus(OrderStatus status) =>
        status == OrderStatus.Available ? OrderStatus.Accepted : OrderStatus.Delivered;
}