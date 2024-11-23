using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Motorcycles;

public class GetMotorcycleResponseDto : BaseResponseDto
{
    public short Year { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }
    public bool Rented { get; set; }
}