using MotoXShare.Application.Domain.Enums;

namespace MotoXShare.Application.Features.DeliveryRiders;

public class SaveDeliveryRiderRequestDto
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string CNPJ { get; set; }
    public string CNH { get; set; }
    public CnhTypes CNHType { get; set; }
}