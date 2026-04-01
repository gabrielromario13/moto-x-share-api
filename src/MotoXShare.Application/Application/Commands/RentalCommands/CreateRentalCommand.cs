using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Domain.Entities;
using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Application.Commands.RentalCommands;

public record CreateRentalCommand(
    int DeliveryRiderId,
    RentalPlanTypes PlanType,
    DateTime ExpectedEndDate,
    DateTime EndDate
) : IRequest<ResultViewModel<int>>
{
    public Rental ToEntity(int motorcycleId) =>
        new(motorcycleId,
            DeliveryRiderId,
            PlanType,
            Rental.CalculateRentalPrice(ExpectedEndDate, EndDate, PlanType),
            DateTime.UtcNow,
            ExpectedEndDate,
            EndDate);
}