using MotoXShare.Domain.Notification;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Motorcycle;

public class DeleteMotorcycleUseCase(
    IRentalRepository rentalRepository,
    IMotorcycleRepository repository,
    NotificationHandler notificationHandler)
{
    public virtual async Task<bool> Action(Guid id)
    {
        var motorcycle = await repository.GetById(id);

        if (motorcycle is null)
            return false;

        var rentedMotorcycle = await rentalRepository.CheckIfMotorcycleIsRented(id);
        if (rentedMotorcycle)
        {
            notificationHandler.Add(new("Moto com locação ativa. Não foi possível realizar exclusão.", "RentedMotorcycle"));
            return false;
        }

        await repository.Remove(motorcycle);

        return true;
    }
}