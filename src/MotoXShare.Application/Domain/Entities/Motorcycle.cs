namespace MotoXShare.Core.Domain.Entities;

public class Motorcycle(short year, string model, string plate) : BaseEntity
{
    public short Year { get; set; } = year;
    public string Model { get; set; } = model;
    public string Plate { get; set; } = plate;
    public bool Rented { get; set; }

    public Rental Rental { get; set; }

    public void ToggleRented()
    {
        Rented = !Rented;
    }
}