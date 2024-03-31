using MotoXShare.Domain.Enums;

namespace MotoXShare.Domain.Model;

public class Rental : BaseEntity
{
    //Won't be possible to complete the rent if there's no motorcycles available!
    //Only delivery riders qualified in category A can make a rental!
    public RentalPlanTypes PlanType { get; set; }
    public decimal RentalPrice { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now.AddDays(1); //TODO: Check if this is the best way to do it!
    public DateTime EndDatePrevision { get; set; }
    public DateTime EndDate { get; set; }

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
            RentalPlanTypes.TirtyDays => 30 * 22,
            _ => 0,
        };

        var timeSpan = endDate - expectedEndDate;

        if (timeSpan.Days > 0)
        {
            return planType switch
            {
                RentalPlanTypes.SevenDays => (decimal)(30 * 0.20) * timeSpan.Days + rentalPrice,
                RentalPlanTypes.FifteenDays => (decimal)(28 * 0.40) * timeSpan.Days + rentalPrice,
                RentalPlanTypes.TirtyDays => (decimal)(22 * 0.60) * timeSpan.Days + rentalPrice,
                _ => 0,
            };
        }
        else
            return Math.Abs(timeSpan.Days) * 50 + rentalPrice;
    }
}