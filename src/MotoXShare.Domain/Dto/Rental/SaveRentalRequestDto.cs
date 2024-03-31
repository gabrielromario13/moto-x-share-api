using MotoXShare.Domain.Enums;

namespace MotoXShare.Domain.Dto.Rental;

public class SaveRentalRequestDto
{
    public Guid DeliveryRiderId { get; set; }
    public RentalPlanTypes PlanType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDatePrevision { get; set; }
    public DateTime EndDate { get; set; }
}