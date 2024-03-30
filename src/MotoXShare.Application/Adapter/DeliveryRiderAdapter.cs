using MotoXShare.Domain.Dto.DeliveryRider;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

public class DeliveryRiderAdapter
{
    public static DeliveryRider ToDomain(SaveDeliveryRiderRequestDto param, Guid id = default) =>
        new(id)
        {
            Name = param.Name,
            CNPJ = param.CNPJ,
            BirthDate = param.BirthDate,
            CNH = param.CNH,
            CNHType = param.CNHType,
            CNHImage = param.CNHImage
        };
}