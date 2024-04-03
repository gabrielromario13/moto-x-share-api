using MotoXShare.Domain.Dto.Rental;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

public class RentalAdapter
{
    public static Rental ToDomain(SaveRentalRequestDto param, Guid motorcycleId) =>
        new()
        {
            MotorcycleId = motorcycleId,
            DeliveryRiderId = param.DeliveryRiderId,
            RentalPrice = Rental.CalculateRentalPrice(param.ExpectedEndDate, param.EndDate, param.PlanType),
            PlanType = param.PlanType,
            ExpectedEndDate = param.ExpectedEndDate,
            EndDate = param.EndDate
        };

    public static GetRentalResponseDto FromDomain(Rental param, DateTime expectedEndDate) =>
        new()
        {
            RentalPrice = Rental.CalculateRentalPrice(expectedEndDate, param.EndDate, param.PlanType)
        };
}