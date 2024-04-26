using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.Order;
using MotoXShare.Domain.Dto.Order;
using System.ComponentModel.DataAnnotations;

namespace MotoXShare.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController(
    ISaveOrderInteractor saveOrderInteractor,
    IUpdateOrderInteractor updateOrderInteractor
) : ControllerBase
{
    private readonly ISaveOrderInteractor _saveOrderInteractor = saveOrderInteractor;
    private readonly IUpdateOrderInteractor _updateOrderInteractor = updateOrderInteractor;

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(SaveOrderRequestDto param)
    {
        var result = await _saveOrderInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", new { });
    }

    [Authorize(Roles = "Admin, User")]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [Required] Guid deliveryRiderId)
    {
        var result = await _updateOrderInteractor.Execute(new(id, deliveryRiderId));

        return result ? NoContent() : NotFound();
    }
}