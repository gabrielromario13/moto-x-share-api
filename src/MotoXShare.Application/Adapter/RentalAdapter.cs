using MotoXShare.Domain.Dto.Rental;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

public class RentalAdapter
{
    public static Rental ToDomain(SaveRentalRequestDto param, Guid motorcycleId, Guid deliveryRiderId) =>
        new()
        {
            MotorcycleId = motorcycleId,
            DeliveryRiderId = deliveryRiderId,
            RentalPrice = Rental.CalculateRentalPrice(param.EndDatePrevision, param.EndDate, param.PlanType),
            PlanType = param.PlanType,
            StartDate = param.StartDate,
            EndDatePrevision = param.EndDatePrevision,
            EndDate = param.EndDate
        };

    public static GetRentalResponseDto FromDomain(Rental param, DateTime returnDate) =>
        new()
        {
            RentalPrice = Rental.CalculateRentalPrice(returnDate, param.EndDate, param.PlanType)
        };
}