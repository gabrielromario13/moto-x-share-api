using MotoXShare.Domain.Enums;

namespace MotoXShare.Domain.Model;

public class DeliveryRider(Guid id) : User(id)
{
    public string CNPJ { get; set; }
    public string CNH { get; set; }
    public CnhTypes CNHType { get; set; }
    public string CNHImage { get; set; }

    public Rental Rental { get; set; }
    public Order Order { get; set; }
}