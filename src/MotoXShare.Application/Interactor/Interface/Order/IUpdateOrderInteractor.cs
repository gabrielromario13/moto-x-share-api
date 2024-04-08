using MotoXShare.Application.Interactor.Base;
using MotoXShare.Domain.Dto.Order;

namespace MotoXShare.Application.Interactor.Interface.Order;

public interface IUpdateOrderInteractor : IInteractorAsync<bool, UpdateOrderRequestDto>
{
}