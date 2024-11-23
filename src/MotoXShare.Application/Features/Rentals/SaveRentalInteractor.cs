using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.Rentals;

public class SaveRentalInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    SaveRentalUseCase saveRentalUseCase
) : InteractorAsync<Guid, SaveRentalRequestDto>(unitOfWork), ISaveRentalInteractor
{
    protected override async Task<Guid> Action(SaveRentalRequestDto param) =>
        await saveRentalUseCase.Action(param);
}