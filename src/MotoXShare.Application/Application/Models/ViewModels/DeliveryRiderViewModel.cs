using MotoXShare.Core.Domain.Entities;
using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Application.Models.ViewModels;

public record DeliveryRiderViewModel(
    int Id,
    string Name,
    string CNPJ,
    DateTime BirthDate,
    string CNH,
    CnhTypes CNHType,
    string CNHImageUrl)
{

    public static DeliveryRiderViewModel FromDomain(DeliveryRider param) =>
        new(param.Id,
            param.FullName,
            param.CNPJ,
            param.BirthDate,
            param.CNH,
            param.CNHType,
            param.CNHImageUrl);
}