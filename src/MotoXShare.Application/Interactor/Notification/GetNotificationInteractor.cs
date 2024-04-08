using MotoXShare.Application.Interactor.Interface.Notification;
using MotoXShare.Application.UseCase.Notification;
using MotoXShare.Domain.Dto.Notification;
using MotoXShare.Infraestructure.UnitOfWork;

namespace MotoXShare.Application.Interactor.Notification;

public class GetNotificationInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    GetNotificationUseCase getNotificationUseCase
) : InteractorAsync<GetNotificationResponseDto, Guid>(unitOfWork), IGetNotificationInteractor
{
    private readonly GetNotificationUseCase _getNotificationUseCase = getNotificationUseCase;

    protected override async Task<GetNotificationResponseDto> Action(Guid param) =>
        await _getNotificationUseCase.Action(param);
}