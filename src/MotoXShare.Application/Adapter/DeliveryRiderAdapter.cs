using MotoXShare.Domain.Dto.DeliveryRider;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

public static class DeliveryRiderAdapter
{
    public static DeliveryRider ToDomain(SaveDeliveryRiderRequestDto param) =>
        new()
        {
            FullName = param.FullName,
            CNPJ = param.CNPJ,
            BirthDate = param.BirthDate,
            CNH = param.CNH,
            CNHType = param.CNHType
        };

    public static GetDeliveryRiderResponseDto FromDomain(DeliveryRider param) =>
        new()
        {
            Id = param.Id,
            Name = param.FullName,
            CNPJ = param.CNPJ,
            BirthDate = param.BirthDate,
            CNH = param.CNH,
            CNHType = param.CNHType,
            CNHImage = param.CNHImage
        };
}