using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Notifications;

public interface IGetNotificationInteractor : IInteractorAsync<GetNotificationResponseDto, Guid>
{
}