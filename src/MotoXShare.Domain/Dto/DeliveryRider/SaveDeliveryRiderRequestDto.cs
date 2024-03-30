using MotoXShare.Domain.Enums;

namespace MotoXShare.Domain.Dto.DeliveryRider;

public class SaveDeliveryRiderRequestDto
{
    public string Name { get; set; }
    public string CNPJ { get; set; }
    public DateTime BirthDate { get; set; }
    public string CNH { get; set; }
    public CNHTypes CNHType { get; set; }
    public string CNHImage { get; set; }
}