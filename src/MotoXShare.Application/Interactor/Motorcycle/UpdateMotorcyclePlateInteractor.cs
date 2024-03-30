using MotoXShare.Application.Interactor.Interface.Motorcycle;
using MotoXShare.Application.UseCase.Motorcycle;
using MotoXShare.Domain.Dto.Motorcycle;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.Motorcycle;

public class UpdateMotorcyclePlateInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    UpdateMotorcyclePlateUseCase updateMotorcyclePlateUseCase
) : InteractorAsync<GetMotorcycleResponseDto, UpdateMotorcyclePlateRequestDto>(unitOfWork), IUpdateMotorcyclePlateInteractor
{
    private readonly UpdateMotorcyclePlateUseCase _updateMotorcyclePlateUseCase = updateMotorcyclePlateUseCase;

    protected override async Task<GetMotorcycleResponseDto> Action(UpdateMotorcyclePlateRequestDto param) =>
        await _updateMotorcyclePlateUseCase.Action(param);
}