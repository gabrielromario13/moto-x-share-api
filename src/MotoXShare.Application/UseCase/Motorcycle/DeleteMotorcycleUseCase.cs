using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Motorcycle;

public class DeleteMotorcycleUseCase(IRentalRepository rentalRepository, IMotorcycleRepository repository)
{
    private readonly IRentalRepository _rentalRepository = rentalRepository;
    private readonly IMotorcycleRepository _repository = repository;

    public virtual async Task<bool> Action(Guid id)
    {
        var motorcycle = await _repository.GetById(id);

        if (motorcycle is null)
        {
            return false; //TODO: Add notification here. ("Não foi possível encontrar a moto informada!")
        }

        var motorcycleRented = await _rentalRepository.CheckIfMotorcycleIsRented(id);

        if (motorcycleRented)
        {
            //TODO: Add notification here. ("Moto com locação ativa. Não foi possível realizar exclusão!")
            return true;
        }

        await _repository.Remove(motorcycle);

        return true;
    }
}