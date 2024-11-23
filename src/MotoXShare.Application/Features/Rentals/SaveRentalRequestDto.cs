using MotoXShare.Application.Domain.Enums;

namespace MotoXShare.Application.Features.Rentals;

public class SaveRentalRequestDto
{
    public Guid DeliveryRiderId { get; set; }
    public RentalPlanTypes PlanType { get; set; }
    public DateTime ExpectedEndDate { get; set; }
    public DateTime EndDate { get; set; }
}