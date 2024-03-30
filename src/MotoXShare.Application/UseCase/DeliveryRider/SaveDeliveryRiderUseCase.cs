using DocumentValidator;
using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.DeliveryRider;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.DeliveryRider;

public class SaveDeliveryRiderUseCase(IDeliveryRiderRepository repository)
{
    private readonly IDeliveryRiderRepository _repository = repository;

    public virtual async Task<Guid> Action(SaveDeliveryRiderRequestDto param)
    {
        var existentCnpj = await _repository.CheckIfCnpjExists(param.CNPJ);
        var existentCnh = await _repository.CheckIfCnhExists(param.CNH);

        //TODO: Find a better way to do those validations
        if (existentCnpj)
            return Guid.Empty; //TODO: Add notification here. ("CNPJ informado já está cadastrado!")

        if (existentCnh)
            return Guid.Empty; //TODO: Add notification here. ("CNH informada já está cadastrada!")

        ValidateDocuments(param);

        var deliveryRider = DeliveryRiderAdapter.ToDomain(param);

        await _repository.Add(deliveryRider);

        return deliveryRider.Id;
    }

    private static void ValidateDocuments(SaveDeliveryRiderRequestDto param)
    {
        if (!CnpjValidation.Validate(param.CNPJ))
        {
            //TODO: Add notification here. ("CNPJ inválido!")
        }

        if (!CnhValidation.Validate(param.CNH))
        {
            //TODO: Add notification here. ("CNH inválida!")
        }
    }
}