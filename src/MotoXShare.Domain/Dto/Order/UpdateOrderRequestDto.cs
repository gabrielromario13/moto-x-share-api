using System.Text.Json.Serialization;

namespace MotoXShare.Domain.Dto.Order;

public class UpdateOrderRequestDto(Guid id, Guid deliveryRiderId)
{
    [JsonIgnore]
    public Guid Id { get; set; } = id;
    public Guid DeliveryRiderId { get; set; } = deliveryRiderId;
}