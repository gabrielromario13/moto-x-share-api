using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.Rental;
using MotoXShare.Domain.Dto.Rental;

namespace MotoXShare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    public async Task<IActionResult> Create([FromBody] SaveRentalRequestDto param)
    {
        var result = await _saveRentalInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", string.Empty);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetRentalResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid id, [FromQuery] DateTime returnDate)
    {
        var result = await _getRentalInteractor.Execute(new(id, returnDate));

        return Ok(result);
    }
}