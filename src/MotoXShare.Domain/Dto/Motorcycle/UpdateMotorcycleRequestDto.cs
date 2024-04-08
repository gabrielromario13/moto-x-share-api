namespace MotoXShare.Domain.Dto.Motorcycle;

public class UpdateMotorcycleRequestDto(Guid id, string plate)
{
    public Guid Id { get; set; } = id;
    public string Plate { get; set; } = plate;
}