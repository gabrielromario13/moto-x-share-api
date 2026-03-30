using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.Notifications;

public class GetNotificationInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    GetNotificationUseCase getNotificationUseCase
) : InteractorAsync<GetNotificationResponseDto, int>(unitOfWork), IGetNotificationInteractor
{
    protected override async Task<GetNotificationResponseDto> Action(int param) =>
        await getNotificationUseCase.Action(param);
}