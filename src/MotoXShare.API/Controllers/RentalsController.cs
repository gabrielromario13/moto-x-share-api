using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Features.Rentals;

namespace MotoXShare.API.Controllers;

[Authorize(Roles = "Admin, DeliveryRider")]
[ApiController]
[Route("api/v1/[controller]")]
public class RentalsController(
    ISaveRentalInteractor saveRentalInteractor,
    IGetRentalInteractor getRentalInteractor
) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(SaveRentalRequestDto param)
    {
        var result = await saveRentalInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", string.Empty);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GetRentalResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id, [FromQuery] DateTime returnDate)
    {
        var result = await getRentalInteractor.Execute(new(id, returnDate));

        return result == default ? NotFound() : Ok(result);
    }
}