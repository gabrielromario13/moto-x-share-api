using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Domain.Entities;
using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Application.Commands.DeliveryRiderCommand;

public class CreateDeliveryRiderCommand : IRequest<ResultViewModel<int>>
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string CNPJ { get; set; }
    public string CNH { get; set; }
    public CnhTypes CNHType { get; set; }
    public string CNHImageUrl { get; set; }

    public DeliveryRider ToEntity() =>
        new(FullName, BirthDate, CNPJ, CNH, CNHType, CNHImageUrl);
}