using MotoXShare.Application.Domain.Model;
using MotoXShare.Application.Features.DeliveryRiders;
using MotoXShare.Application.Features.Motorcycles;
using MotoXShare.Application.Features.Notifications;

namespace MotoXShare.Application.Features.Rentals;

public class SaveRentalUseCase(
    IDeliveryRiderRepository deliveryRiderRepository,
    IMotorcycleRepository motorcycleRepository,
    IRentalRepository repository,
    NotificationHandler notificationHandler)
{
    public virtual async Task<Guid> Action(SaveRentalRequestDto param)
    {
        var motorcycle = await motorcycleRepository.GetSingle(x => !x.Rented);

        await ValidateRentalRequirements(motorcycle, param.DeliveryRiderId);

        if (notificationHandler.HasNotification())
            return Guid.Empty;

        var rental = RentalAdapter.ToDomain(param, motorcycle.Id);

        await repository.Add(rental);

        motorcycle.ToggleRented();
        await motorcycleRepository.Update(motorcycle);

        return rental.Id;
    }

    private async Task ValidateRentalRequirements(Motorcycle motorcycle, Guid deliveryRiderId)
    {
        if (motorcycle is null)
            notificationHandler.Add(new("Nenhuma moto disponível para locação.", "NoMotorcyclesAvailable"));

        var validCnhType = await deliveryRiderRepository.CheckIfCnhTypeIsValid(deliveryRiderId);
        if (!validCnhType)
            notificationHandler.Add(new("Tipo de CNH inválido.", "InvalidCnhType"));

        var activeRental = await repository.CheckActiveRentalByDeliveryRiderId(deliveryRiderId);
        if (activeRental)
            notificationHandler.Add(new("Você já possui um plano de locação ativo.", "ActiveRental"));

    }
}