using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.Notification;
using MotoXShare.Domain.Dto.Notification;

namespace MotoXShare.API.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/v1/[controller]")]
public class NotificationsController(IGetNotificationInteractor getNotificationInteractor) : ControllerBase
{
    [HttpGet("{orderId:guid}")]
    [ProducesResponseType(typeof(GetNotificationResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByOrderId(Guid orderId)
    {
        var result = await getNotificationInteractor.Execute(orderId);

        return result == default ? NotFound() : Ok(result);
    }
}