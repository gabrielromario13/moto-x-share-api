using MotoXShare.Application.Interactor.Base;
using MotoXShare.Domain.Dto.Motorcycle;

namespace MotoXShare.Application.Interactor.Interface;

public interface IGetMotorcyclesInteractor : 
    IInteractorAsync<IEnumerable<GetMotorcycleResponseDto>, GetMotorcycleRequestDto>
{
}