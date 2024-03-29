using MotoXShare.Domain.Enums;

namespace MotoXShare.Domain.Model;

public class Order(Guid id) : BaseEntity(id)
{
    public DateTime CreatedAt { get; set; }
    public double DeliveryPrice { get; set; }
    public OrderStatus Status { get; set; }
}