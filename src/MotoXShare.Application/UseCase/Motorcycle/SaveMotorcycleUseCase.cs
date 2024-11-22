using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.Motorcycle;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Motorcycle;

public class SaveMotorcycleUseCase(IMotorcycleRepository repository)
{
    public virtual async Task<Guid> Action(SaveMotorcycleRequestDto param)
    {
        var motorcycle = MotorcycleAdapter.ToDomain(param);

        await repository.Add(motorcycle);

        return motorcycle.Id;
    }
}