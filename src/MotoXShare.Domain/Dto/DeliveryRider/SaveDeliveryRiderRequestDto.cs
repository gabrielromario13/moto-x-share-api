using MotoXShare.Domain.Dto.User;
using MotoXShare.Domain.Enums;

namespace MotoXShare.Domain.Dto.DeliveryRider;

public class SaveDeliveryRiderRequestDto : SaveUserRequestDto
{
    public string CNPJ { get; set; }
    public string CNH { get; set; }
    public CnhTypes CNHType { get; set; }
}