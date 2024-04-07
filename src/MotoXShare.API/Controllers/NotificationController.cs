using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.Notification;
using MotoXShare.Domain.Dto.Notification;

namespace MotoXShare.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NotificationsController(IGetNotificationInteractor getNotificationInteractor) : ControllerBase
{
    private readonly IGetNotificationInteractor _getNotificationInteractor = getNotificationInteractor;

    [HttpGet("{orderId}")]
    [ProducesResponseType(typeof(GetNotificationResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByOrderId(Guid orderId)
    {
        var result = await _getNotificationInteractor.Execute(orderId);

        return result == default ? NotFound() : Ok(result);
    }
}