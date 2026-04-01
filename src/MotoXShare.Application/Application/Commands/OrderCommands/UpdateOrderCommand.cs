using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;
using System.Text.Json.Serialization;

namespace MotoXShare.Core.Application.Commands.OrderCommands;

public record UpdateOrderCommand([property: JsonIgnore]int Id, int DeliveryRiderId)
    : IRequest<ResultViewModel>
{
}