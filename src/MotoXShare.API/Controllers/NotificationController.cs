using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Features.Notifications;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Application.Queries.DeliveryRiderNotificationQueries;

namespace MotoXShare.API.Controllers;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/v1/[controller]")]
public class NotificationsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{orderId:guid}")]
    [ProducesResponseType(typeof(DeliveryRiderNotificationViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByOrderId(GetDeliveryRiderNotificationQuery query)
    {
        var result = await mediator.Send(query);

        return result.IsSuccess ? NotFound() : Ok(result);
    }
}