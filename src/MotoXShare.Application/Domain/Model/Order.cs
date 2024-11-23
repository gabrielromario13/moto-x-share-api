using MotoXShare.Application.Domain.Enums;

namespace MotoXShare.Application.Domain.Model;

public class Order : BaseEntity
{
    public decimal DeliveryPrice { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid? DeliveryRiderId { get; set; }
    public virtual DeliveryRider DeliveryRider { get; set; }

    public void Update(Guid deliveryRiderId, OrderStatus status)
    {
        DeliveryRiderId = !DeliveryRiderId.HasValue ? deliveryRiderId : DeliveryRiderId;
        Status = GetStatus(status);
    }

    private static OrderStatus GetStatus(OrderStatus status) =>
        status == OrderStatus.Available ? OrderStatus.Accepted : OrderStatus.Delivered;
}