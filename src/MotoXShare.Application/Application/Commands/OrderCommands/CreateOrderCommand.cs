using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Domain.Entities;
using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Application.Commands.OrderCommands;

public record CreateOrderCommand(
    decimal DeliveryPrice,
    OrderStatus Status,
    DateTime CreatedAt
) : IRequest<ResultViewModel<int>>
{
    public Order ToEntity() =>
        new(DeliveryPrice, Status, CreatedAt);
}