using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.DeliveryRider;
using MotoXShare.Domain.Dto.DeliveryRider;

namespace MotoXShare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeliveryRidersController(ISaveDeliveryRiderInteractor saveDeliveryRiderInteractor) : ControllerBase
{
    private readonly ISaveDeliveryRiderInteractor _saveDeliveryRiderInteractor = saveDeliveryRiderInteractor;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] SaveDeliveryRiderRequestDto param)
    {
        var result = await _saveDeliveryRiderInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", new { });
    }
}