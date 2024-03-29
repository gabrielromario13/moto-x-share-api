using MotoXShare.Application.Interactor.Interface;
using MotoXShare.Application.UseCase.Motorcycle;
using MotoXShare.Domain.Dto.Motorcycle;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.Motorcycle;

public class UpdateMotorcyclePlateInteractor
    : InteractorAsync<GetMotorcycleResponseDto, UpdateMotorcyclePlateRequestDto>, IUpdateMotorcyclePlateInteractor
{
    private readonly UpdateMotorcyclePlateUseCase _updateMotorcyclePlateUseCase;

    public UpdateMotorcyclePlateInteractor(
        EntityFrameworkUnitOfWorkAsync unitOfWork,
        UpdateMotorcyclePlateUseCase updateMotorcyclePlateUseCase
    ) : base(unitOfWork)
    {
        _updateMotorcyclePlateUseCase = updateMotorcyclePlateUseCase;
    }

    protected override async Task<GetMotorcycleResponseDto> Action(UpdateMotorcyclePlateRequestDto param) =>
        await _updateMotorcyclePlateUseCase.Action(param);
}