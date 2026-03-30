using DocumentValidator;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoXShare.Application.Features.Notifications;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;

namespace MotoXShare.Core.Application.Commands.DeliveryRiderCommand;

public class CreateDeliveryRiderCommandHandler(
    AppDbContext context,
    NotificationHandler notificationHandler)
    : IRequestHandler<CreateDeliveryRiderCommand, ResultViewModel<int>>
{
    public virtual async Task<ResultViewModel<int>> Handle(
        CreateDeliveryRiderCommand request,
        CancellationToken token)
    {
        await ValidateDocuments(request);

        if (notificationHandler.HasNotification())
            return default;

        var deliveryRider = request.ToEntity();

        await context.DeliveryRiders.AddAsync(deliveryRider);
        context.SaveChanges();

        return ResultViewModel<int>.Success(deliveryRider.Id);
    }

    private async Task ValidateDocuments(CreateDeliveryRiderCommand param)
    {
        var existentCnpj = await context.DeliveryRiders.AnyAsync(d => d.CNPJ == param.CNPJ);
        if (existentCnpj)
            notificationHandler.Add(new("CNPJ informado já existe.", "ExistentCnpj"));

        var existentCnh = await context.DeliveryRiders.AnyAsync(d => d.CNH == param.CNH);
        if (existentCnh)
            notificationHandler.Add(new("CNH informado já existe.", "ExistentCnh"));

        if (!CnpjValidation.Validate(param.CNPJ))
            notificationHandler.Add(new("CNPJ inválido.", "InvalidCnpj"));

        if (!CnhValidation.Validate(param.CNH))
            notificationHandler.Add(new("CNH inválido.", "InvalidCnh"));
    }
}