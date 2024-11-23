using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.Rentals;

public class GetRentalInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    GetRentalUseCase getRentalUseCase
) : InteractorAsync<GetRentalResponseDto, GetRentalRequestDto>(unitOfWork), IGetRentalInteractor
{
    protected override async Task<GetRentalResponseDto> Action(GetRentalRequestDto param) =>
        await getRentalUseCase.Action(param);
}