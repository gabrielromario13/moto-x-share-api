using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Domain.Entities;

public class Rental(RentalPlanTypes planType, decimal rentalPrice, DateTime startDate, DateTime expectedEndDate, DateTime endDate) : BaseEntity
{
    public RentalPlanTypes PlanType { get; set; } = planType;
    public decimal RentalPrice { get; set; } = rentalPrice;
    public DateTime StartDate { get; set; } = startDate;
    public DateTime ExpectedEndDate { get; set; } = expectedEndDate;
    public DateTime EndDate { get; set; } = endDate;

    public Guid DeliveryRiderId { get; set; }
    public Guid MotorcycleId { get; set; }
    public virtual DeliveryRider DeliveryRider { get; set; }
    public virtual Motorcycle Motorcycle { get; set; }

    public static decimal CalculateRentalPrice(DateTime expectedEndDate, DateTime endDate, RentalPlanTypes planType)
    {
        var rentalPrice = planType switch
        {
            RentalPlanTypes.SevenDays => 7 * 30,
            RentalPlanTypes.FifteenDays => 15 * 28,
            RentalPlanTypes.ThirtyDays => 30 * 22,
            _ => 0,
        };

        var timeSpan = endDate.Date - expectedEndDate.Date;

        if (timeSpan.Days > 0)
        {
            return planType switch
            {
                RentalPlanTypes.SevenDays => (decimal)(30 * 0.20) * timeSpan.Days + rentalPrice,
                RentalPlanTypes.FifteenDays => (decimal)(28 * 0.40) * timeSpan.Days + rentalPrice,
                RentalPlanTypes.ThirtyDays => (decimal)(22 * 0.60) * timeSpan.Days + rentalPrice,
                _ => 0,
            };
        }
        else
            return Math.Abs(timeSpan.Days) * 50 + rentalPrice;
    }
}