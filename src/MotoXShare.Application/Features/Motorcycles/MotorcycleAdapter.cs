using MotoXShare.Application.Domain.Model;

namespace MotoXShare.Application.Features.Motorcycles;

public static class MotorcycleAdapter
{
    public static Motorcycle ToDomain(SaveMotorcycleRequestDto param) =>
        new()
        {
            Year = param.Year,
            Model = param.Model,
            Plate = param.Plate
        };

    public static GetMotorcycleResponseDto FromDomain(Motorcycle param) =>
        new()
        {
            Id = param.Id,
            Year = param.Year,
            Model = param.Model,
            Plate = param.Plate,
            Rented = param.Rented
        };
}