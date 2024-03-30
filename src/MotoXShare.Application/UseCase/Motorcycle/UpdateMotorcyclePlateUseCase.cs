using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.Motorcycle;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.Motorcycle;

public class UpdateMotorcyclePlateUseCase(IMotorcycleRepository repository)
{
    private readonly IMotorcycleRepository _repository = repository;

    public virtual async Task<GetMotorcycleResponseDto> Action(UpdateMotorcyclePlateRequestDto param)
    {
        var motorcycle = await _repository.GetSingle(x => x.Id == param.Id);

        if (motorcycle is null)
            return default;

        motorcycle.SetPlate(param.Plate);

        await _repository.Update(motorcycle);

        return MotorcycleAdapter.FromDomain(motorcycle);
    }
}