using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Domain.Entities;

public class DeliveryRider(string fullName, DateTime birthDate, string cnpj, string cnh, CnhTypes cnhType, string cnhImageUrl) : BaseEntity
{
    public string FullName { get; set; } = fullName;
    public DateTime BirthDate { get; set; } = birthDate;
    public string CNPJ { get; set; } = cnpj;
    public string CNH { get; set; } = cnh;
    public CnhTypes CNHType { get; set; } = cnhType;
    public string CNHImageUrl { get; set; } = cnhImageUrl;

    public Rental Rental { get; set; }
}