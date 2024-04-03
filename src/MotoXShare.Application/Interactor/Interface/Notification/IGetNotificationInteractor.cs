using MotoXShare.Application.Interactor.Base;
using MotoXShare.Domain.Dto.Notification;

namespace MotoXShare.Application.Interactor.Interface.Notification;

public interface IGetNotificationInteractor : IInteractorAsync<GetNotificationResponseDto, Guid>
{
}