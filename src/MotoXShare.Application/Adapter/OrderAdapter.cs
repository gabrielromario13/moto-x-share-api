using MotoXShare.Domain.Dto.Order;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

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