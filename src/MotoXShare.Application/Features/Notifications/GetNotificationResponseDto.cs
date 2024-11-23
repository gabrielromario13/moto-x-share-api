using MotoXShare.Application.Features.DeliveryRiders;

namespace MotoXShare.Application.Features.Notifications;

public class GetNotificationResponseDto
{
    public Guid OrderId { get; set; }
    public IEnumerable<GetDeliveryRiderResponseDto> DeliveryRiders { get; set; }
}