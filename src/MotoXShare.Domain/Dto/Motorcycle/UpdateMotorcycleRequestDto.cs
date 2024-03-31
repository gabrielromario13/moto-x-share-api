namespace MotoXShare.Domain.Dto.Motorcycle;

public class UpdateMotorcycleRequestDto
{
    public Guid Id { get; set; }
    public bool Rented { get; set; }
    public string Plate { get; set; }
}