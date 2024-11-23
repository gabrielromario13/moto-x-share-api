using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Motorcycles;

public interface IDeleteMotorcycleInteractor : IInteractorAsync<bool, Guid>
{
}