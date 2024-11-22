using DocumentValidator;
using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.DeliveryRider;
using MotoXShare.Domain.Notification;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.DeliveryRider;

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