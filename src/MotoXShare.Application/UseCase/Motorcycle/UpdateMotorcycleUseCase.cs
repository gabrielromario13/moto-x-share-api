using MotoXShare.Domain.Dto.Motorcycle;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Motorcycle;

public class UpdateMotorcycleUseCase(IMotorcycleRepository repository)
{
    private readonly IMotorcycleRepository _repository = repository;

    public virtual async Task<bool> Action(UpdateMotorcycleRequestDto param)
    {
        var motorcycle = await _repository.GetById(param.Id);

        if (motorcycle is null)
            return false;

        motorcycle.Plate = param.Plate;

        await _repository.Update(motorcycle);

        return true;
    }
}