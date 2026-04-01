using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;

namespace MotoXShare.Core.Application.Queries.DeliveryRiderNotificationQueries;

public record GetDeliveryRiderNotificationQuery(int OrderId)
    : IRequest<ResultViewModel<DeliveryRiderNotificationViewModel>>;