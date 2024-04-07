using MotoXShare.Domain.Notification;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Motorcycle;

public class DeleteMotorcycleUseCase(
    IRentalRepository rentalRepository, 
    IMotorcycleRepository repository, 
    NotificationHandler notificationHandler)
{
    private readonly IRentalRepository _rentalRepository = rentalRepository;
    private readonly IMotorcycleRepository _repository = repository;
    private readonly NotificationHandler _notificationHandler = notificationHandler;

    public virtual async Task<bool> Action(Guid id)
    {
        var motorcycle = await _repository.GetById(id); 

        if (motorcycle is null)
            return false;

        var rentedMotorcycle = await _rentalRepository.CheckIfMotorcycleIsRented(id);
        if (rentedMotorcycle)
        {
            _notificationHandler.Add(new("Moto com locação ativa. Não foi possível realizar exclusão.", "RentedMotorcycle"));
            return false;
        }

        await _repository.Remove(motorcycle);

        return true;
    }
}