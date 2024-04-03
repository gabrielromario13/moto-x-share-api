using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.Rental;
using MotoXShare.Domain.Notification;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Rental;

public class SaveRentalUseCase(
    IDeliveryRiderRepository deliveryRiderRepository,
    IMotorcycleRepository motorcycleRepository,
    IRentalRepository repository,
    NotificationHandler notificationHandler
)
{
    private readonly IDeliveryRiderRepository _deliveryRiderRepository = deliveryRiderRepository;
    private readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;
    private readonly IRentalRepository _repository = repository;
    private readonly NotificationHandler _notificationHandler = notificationHandler;

    public virtual async Task<Guid> Action(SaveRentalRequestDto param)
    {
        var validCnhType = await _deliveryRiderRepository.CheckIfCnhTypeIsValid(param.DeliveryRiderId);
        if (!validCnhType)
        {
            _notificationHandler.Add(new("Tipo de CNH inválido.", "InvalidCnhType"));
            return Guid.Empty;
        }

        var activeRental = await _repository.CheckActiveRentalByDeliveryRiderId(param.DeliveryRiderId);
        if (activeRental)
        {
            _notificationHandler.Add(new("Você já possui um plano de locação ativo.", "ActiveRental"));
            return Guid.Empty;
        }

        var motorcycle = await _motorcycleRepository.GetSingle(x => !x.Rented);
        if (motorcycle is null)
        {
            _notificationHandler.Add(new("Nenhuma moto disponível para locação.", "NoMotorcyclesAvailable"));
            return Guid.Empty;
        }

        var rental = RentalAdapter.ToDomain(param, motorcycle.Id);

        await _repository.Add(rental);

        motorcycle.ToggleRented();

        await _motorcycleRepository.Update(motorcycle);

        return rental.Id;
    }
}