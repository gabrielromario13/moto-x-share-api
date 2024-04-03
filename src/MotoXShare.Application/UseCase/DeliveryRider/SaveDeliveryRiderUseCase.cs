using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.DeliveryRider;
using MotoXShare.Domain.Notification;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.DeliveryRider;

public class SaveDeliveryRiderUseCase(IDeliveryRiderRepository repository, NotificationHandler notificationHandler)
{
    private readonly IDeliveryRiderRepository _repository = repository;
    private readonly NotificationHandler _notificationHandler = notificationHandler;

    public virtual async Task<Guid> Action(SaveDeliveryRiderRequestDto param)
    {
        var validDocuments = await ValidateDocuments(param);
        
        if (!validDocuments)
            return Guid.Empty;

        var deliveryRider = DeliveryRiderAdapter.ToDomain(param);

        await _repository.Add(deliveryRider);

        return deliveryRider.Id;
    }

    private async Task<bool> ValidateDocuments(SaveDeliveryRiderRequestDto param)
    {
        var existentCnpj = await _repository.CheckIfCnpjExists(param.CNPJ);
        if (existentCnpj)
        {
            _notificationHandler.Add(new("CNPJ informado já existe.", "ExistentCnpj"));
            return false;
        }

        var existentCnh = await _repository.CheckIfCnhExists(param.CNH);
        if (existentCnh)
        {
            _notificationHandler.Add(new("CNH informado já existe.", "ExistentCnh"));
            return false;
        }

        return true;
    }
}