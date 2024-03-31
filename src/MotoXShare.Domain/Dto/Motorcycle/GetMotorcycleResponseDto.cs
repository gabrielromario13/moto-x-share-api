namespace MotoXShare.Domain.Dto.Motorcycle;

public class GetMotorcycleResponseDto : BaseResponseDto
{
    public short Year { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }
    public bool Rented { get; set; }
}