using MotoXShare.Application.Domain.Model;

namespace MotoXShare.Application.Features.Orders;

public static class OrderAdapter
{
    public static Order ToDomain(SaveOrderRequestDto param) =>
        new()
        {
            DeliveryPrice = param.DeliveryPrice,
            Status = param.Status,
            CreatedAt = param.CreatedAt
        };
}