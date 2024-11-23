using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Motorcycles;

public interface IGetMotorcyclesInteractor : IInteractorAsync<IEnumerable<GetMotorcycleResponseDto>, GetMotorcycleRequestDto>
{
}