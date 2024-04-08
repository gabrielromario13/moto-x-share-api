using MotoXShare.Domain.Dto.DeliveryRider;

namespace MotoXShare.Domain.Dto.Notification;

public class GetNotificationResponseDto
{
    public Guid OrderId { get; set; }
    public IEnumerable<GetDeliveryRiderResponseDto> DeliveryRiders { get; set; }
}