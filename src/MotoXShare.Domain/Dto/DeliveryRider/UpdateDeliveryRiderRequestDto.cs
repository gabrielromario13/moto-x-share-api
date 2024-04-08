using Microsoft.AspNetCore.Http;

namespace MotoXShare.Domain.Dto.DeliveryRider;

public class UpdateDeliveryRiderRequestDto(Guid id, IFormFile cnhImage)
{
    public Guid Id { get; set; } = id;
    public IFormFile CnhImage { get; set; } = cnhImage;
}