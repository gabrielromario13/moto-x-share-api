using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Motorcycles;

public interface ISaveMotorcycleInteractor : IInteractorAsync<Guid, SaveMotorcycleRequestDto>
{
}