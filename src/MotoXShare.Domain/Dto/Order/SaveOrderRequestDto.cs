using MotoXShare.Domain.Enums;

namespace MotoXShare.Domain.Dto.Order;

public class SaveOrderRequestDto
{
    public decimal DeliveryPrice { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}