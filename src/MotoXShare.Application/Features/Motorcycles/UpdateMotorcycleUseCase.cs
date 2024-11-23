namespace MotoXShare.Application.Features.Motorcycles;

public class UpdateMotorcycleUseCase(IMotorcycleRepository repository)
{
    public virtual async Task<bool> Action(UpdateMotorcycleRequestDto param)
    {
        var motorcycle = await repository.GetById(param.Id);

        if (motorcycle is null)
            return false;

        motorcycle.Plate = param.Plate;

        await repository.Update(motorcycle);

        return true;
    }
}