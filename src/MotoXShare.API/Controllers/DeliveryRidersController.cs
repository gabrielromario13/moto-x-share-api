using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.DeliveryRider;
using MotoXShare.Domain.Dto.DeliveryRider;

namespace MotoXShare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeliveryRidersController(
    ISaveDeliveryRiderInteractor saveDeliveryRiderInteractor,
    IUpdateDeliveryRiderInteractor updateDeliveryRiderInteractor
) : ControllerBase
{
    private readonly ISaveDeliveryRiderInteractor _saveDeliveryRiderInteractor = saveDeliveryRiderInteractor;
    private readonly IUpdateDeliveryRiderInteractor _updateDeliveryRiderInteractor = updateDeliveryRiderInteractor;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] SaveDeliveryRiderRequestDto param)
    {
        var result = await _saveDeliveryRiderInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", new { });
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateCnhImage(Guid id, IFormFile cnhImage)
    {
        await _updateDeliveryRiderInteractor.Execute(new(id, cnhImage));
        
        return Ok();
    }
}