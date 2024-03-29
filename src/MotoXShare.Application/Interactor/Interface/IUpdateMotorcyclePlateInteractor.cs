using MotoXShare.Application.Interactor.Base;
using MotoXShare.Domain.Dto.Motorcycle;

namespace MotoXShare.Application.Interactor.Interface;

public interface IUpdateMotorcyclePlateInteractor : IInteractorAsync<GetMotorcycleResponseDto, UpdateMotorcyclePlateRequestDto>
{
}