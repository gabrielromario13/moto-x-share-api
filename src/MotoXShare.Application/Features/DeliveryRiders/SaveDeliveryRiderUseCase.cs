using DocumentValidator;
using MotoXShare.Application.Features.Notifications;

namespace MotoXShare.Application.Features.DeliveryRiders;

public class SaveDeliveryRiderUseCase(IDeliveryRiderRepository repository, NotificationHandler notificationHandler)
{
    public virtual async Task<Guid> Action(SaveDeliveryRiderRequestDto param)
    {
        await ValidateDocuments(param);

        if (notificationHandler.HasNotification())
            return Guid.Empty;

        var deliveryRider = DeliveryRiderAdapter.ToDomain(param);

        await repository.Add(deliveryRider);

        return deliveryRider.Id;
    }

    private async Task ValidateDocuments(SaveDeliveryRiderRequestDto param)
    {
        var existentCnpj = await repository.CheckIfCnpjExists(param.CNPJ);
        if (existentCnpj)
            notificationHandler.Add(new("CNPJ informado já existe.", "ExistentCnpj"));

        var existentCnh = await repository.CheckIfCnhExists(param.CNH);
        if (existentCnh)
            notificationHandler.Add(new("CNH informado já existe.", "ExistentCnh"));

        if (!CnpjValidation.Validate(param.CNPJ))
            notificationHandler.Add(new("CNPJ inválido.", "InvalidCnpj"));

        if (!CnhValidation.Validate(param.CNH))
            notificationHandler.Add(new("CNH inválido.", "InvalidCnh"));
    }
}