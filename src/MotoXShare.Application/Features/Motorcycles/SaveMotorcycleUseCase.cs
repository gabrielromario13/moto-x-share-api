namespace MotoXShare.Application.Features.Motorcycles;

public class SaveMotorcycleUseCase(IMotorcycleRepository repository)
{
    public virtual async Task<Guid> Action(SaveMotorcycleRequestDto param)
    {
        var motorcycle = MotorcycleAdapter.ToDomain(param);

        await repository.Add(motorcycle);

        return motorcycle.Id;
    }
}