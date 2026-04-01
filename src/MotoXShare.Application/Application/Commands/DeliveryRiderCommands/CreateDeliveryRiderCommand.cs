using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Domain.Entities;
using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Application.Commands.DeliveryRiderCommands;

public record CreateDeliveryRiderCommand(
    string FullName,
    DateTime BirthDate,
    string CNPJ,
    string CNH,
    CnhTypes CNHType,
    string CNHImageUrl
) : IRequest<ResultViewModel<int>>
{
    public DeliveryRider ToEntity() =>
        new(FullName, BirthDate, CNPJ, CNH, CNHType, CNHImageUrl);
}