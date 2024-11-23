using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Motorcycles;

public interface IUpdateMotorcycleInteractor : IInteractorAsync<bool, UpdateMotorcycleRequestDto>
{
}