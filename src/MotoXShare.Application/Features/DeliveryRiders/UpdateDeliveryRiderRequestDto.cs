using Microsoft.AspNetCore.Http;

namespace MotoXShare.Application.Features.DeliveryRiders;

public class UpdateDeliveryRiderRequestDto(Guid id, IFormFile cnhImage)
{
    public Guid Id { get; set; } = id;
    public IFormFile CnhImage { get; set; } = cnhImage;
}