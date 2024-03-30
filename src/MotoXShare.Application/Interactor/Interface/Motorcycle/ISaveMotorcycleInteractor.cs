using MotoXShare.Application.Interactor.Base;
using MotoXShare.Domain.Dto.Motorcycle;

namespace MotoXShare.Application.Interactor.Interface.Motorcycle;

public interface ISaveMotorcycleInteractor : IInteractorAsync<Guid, SaveMotorcycleRequestDto>
{
}