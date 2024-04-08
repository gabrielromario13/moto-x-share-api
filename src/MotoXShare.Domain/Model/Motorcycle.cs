using MotoXShare.Domain.Base;

namespace MotoXShare.Domain.Model;

public class Motorcycle : BaseEntity
{
    public short Year { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }
    public bool Rented { get; set; }

    public Rental Rental { get; set; }

    public void ToggleRented()
    {
        Rented = !Rented;
    }
}