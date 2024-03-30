namespace MotoXShare.Domain.Model;

public class Motorcycle(Guid id) : BaseEntity(id)
{
    public short Year { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }

    public void SetPlate(string plate)
    {
        Plate = plate;
    }
}