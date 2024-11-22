using MotoXShare.Application.Interactor.Interface.Rental;
using MotoXShare.Application.UseCase.Rental;
using MotoXShare.Domain.Dto.Rental;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.Rental;

public class SaveRentalInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    SaveRentalUseCase saveRentalUseCase
) : InteractorAsync<Guid, SaveRentalRequestDto>(unitOfWork), ISaveRentalInteractor
{
    protected override async Task<Guid> Action(SaveRentalRequestDto param) =>
        await saveRentalUseCase.Action(param);
}