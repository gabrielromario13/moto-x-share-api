using MotoXShare.Application.Domain.Enums;

namespace MotoXShare.Application.Features.Orders;

public class SaveOrderRequestDto
{
    public decimal DeliveryPrice { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}