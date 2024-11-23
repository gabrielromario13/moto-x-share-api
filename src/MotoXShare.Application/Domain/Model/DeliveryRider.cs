using MotoXShare.Application.Domain.Enums;

namespace MotoXShare.Application.Domain.Model;

public class DeliveryRider : BaseEntity
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string CNPJ { get; set; }
    public string CNH { get; set; }
    public CnhTypes CNHType { get; set; }
    public string CNHImage { get; set; }

    public Rental Rental { get; set; }
}