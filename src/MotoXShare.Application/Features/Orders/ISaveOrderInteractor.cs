using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Orders;

public interface ISaveOrderInteractor : IInteractorAsync<Guid, SaveOrderRequestDto>
{
}