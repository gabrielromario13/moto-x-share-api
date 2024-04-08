using MotoXShare.Domain.Dto.Motorcycle;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

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