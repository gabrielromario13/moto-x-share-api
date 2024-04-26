using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.Rental;
using MotoXShare.Domain.Dto.Rental;

namespace MotoXShare.API.Controllers;

[Authorize(Roles = "Admin, User")]
[ApiController]
[Route("api/v1/[controller]")]
public class RentalsController(
    ISaveRentalInteractor saveRentalInteractor,
    IGetRentalInteractor getRentalInteractor
) : ControllerBase
{
    private readonly ISaveRentalInteractor _saveRentalInteractor = saveRentalInteractor;
    private readonly IGetRentalInteractor _getRentalInteractor = getRentalInteractor;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(SaveRentalRequestDto param)
    {
        var result = await _saveRentalInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", string.Empty);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetRentalResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id, [FromQuery] DateTime returnDate)
    {
        var result = await _getRentalInteractor.Execute(new(id, returnDate));

        return result == default ? NotFound() : Ok(result);
    }
}