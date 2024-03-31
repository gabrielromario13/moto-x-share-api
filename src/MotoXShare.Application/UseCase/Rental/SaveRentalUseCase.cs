using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.Rental;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Rental;

public class SaveRentalUseCase(
    IDeliveryRiderRepository deliveryRiderRepository,
    IMotorcycleRepository motorcycleRepository,
    IRentalRepository repository
)
{
    private readonly IDeliveryRiderRepository _deliveryRiderRepository = deliveryRiderRepository;
    private readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;
    private readonly IRentalRepository _repository = repository;

    public virtual async Task<Guid> Action(SaveRentalRequestDto param)
    {
        var motorcycle = await _motorcycleRepository.GetSingle(x => !x.Rented);
        if (motorcycle is null)
        { 
            //TODO: Add notification here. ("Nenhuma moto disponível para locação.")

            return Guid.Empty;
        }

        var validCnhType = await _deliveryRiderRepository.CheckIfCnhTypeIsValid(param.DeliveryRiderId);
        if (!validCnhType)
        {
            //TODO: Add notification here. ("Tipo de CNH inválido.")

            return Guid.Empty;
        }

        var activeRental = await _repository.GetSingle(x => x.DeliveryRiderId == param.DeliveryRiderId);
        if (activeRental is not null)
        {
            //TODO: Add notification here. ("Este entregador já possui um plano de locação ativo.")

            return Guid.Empty;
        }

        var rental = RentalAdapter.ToDomain(param, motorcycle.Id, param.DeliveryRiderId);

        await _repository.Add(rental);

        motorcycle.Rented = true;

        await _motorcycleRepository.Update(motorcycle);

        return rental.Id;
    }
}