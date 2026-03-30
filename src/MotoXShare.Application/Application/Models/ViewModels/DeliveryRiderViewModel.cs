using MotoXShare.Core.Domain.Entities;
using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Application.Models.ViewModels;

public class DeliveryRiderViewModel(int id, string name, string cNPJ, DateTime birthDate, string cNH, CnhTypes cNHType, string cNHImage)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string CNPJ { get; set; } = cNPJ;
    public DateTime BirthDate { get; set; } = birthDate;
    public string CNH { get; set; } = cNH;
    public CnhTypes CNHType { get; set; } = cNHType;
    public string CNHImage { get; set; } = cNHImage;

    public static DeliveryRiderViewModel FromDomain(DeliveryRider param) =>
        new(param.Id,
            param.FullName,
            param.CNPJ,
            param.BirthDate,
            param.CNH,
            param.CNHType,
            param.CNHImageUrl);
}