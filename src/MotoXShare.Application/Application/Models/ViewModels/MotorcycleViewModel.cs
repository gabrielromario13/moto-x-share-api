using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Core.Application.Models.ViewModels;

public record MotorcycleViewModel(
    int Id,
    short Year,
    string Model,
    string Plate,
    bool Rented)
{
    public static MotorcycleViewModel FromEntity(Motorcycle motorcycle) =>
        new(motorcycle.Id,
            motorcycle.Year,
            motorcycle.Model,
            motorcycle.Plate,
            motorcycle.Rented);
}