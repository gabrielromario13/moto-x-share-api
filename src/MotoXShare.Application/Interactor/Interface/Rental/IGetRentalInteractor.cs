using MotoXShare.Application.Interactor.Base;
using MotoXShare.Domain.Dto.Rental;

namespace MotoXShare.Application.Interactor.Interface.Rental;

public interface IGetRentalInteractor : IInteractorAsync<GetRentalResponseDto, GetRentalRequestDto>
{
}