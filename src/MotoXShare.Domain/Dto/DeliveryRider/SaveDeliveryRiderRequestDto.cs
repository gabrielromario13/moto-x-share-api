using MotoXShare.Domain.Enums;

namespace MotoXShare.Domain.Dto.DeliveryRider;

public class SaveDeliveryRiderRequestDto
{
    public string FullName { get; set; }
    public string CNPJ { get; set; }
    public DateTime BirthDate { get; set; }
    public string CNH { get; set; }
    public CnhTypes CNHType { get; set; }
}