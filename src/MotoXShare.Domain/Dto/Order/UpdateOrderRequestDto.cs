using System.Text.Json.Serialization;

namespace MotoXShare.Domain.Dto.Order;

public class UpdateOrderRequestDto(Guid orderId, Guid deliveryRiderId)
{
    [JsonIgnore]
    public Guid OrderId { get; set; } = orderId;
    public Guid DeliveryRiderId { get; set; } = deliveryRiderId;
}