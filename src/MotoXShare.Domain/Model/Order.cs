using MotoXShare.Domain.Enums;

namespace MotoXShare.Domain.Model;

public class Order(Guid id) : BaseEntity(id)
{
    public decimal DeliveryPrice { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}