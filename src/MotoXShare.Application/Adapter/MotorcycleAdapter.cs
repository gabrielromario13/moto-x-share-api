using MotoXShare.Domain.Dto.Motorcycle;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

public class MotorcycleAdapter
{
    public static Motorcycle ToDomain(SaveMotorcycleRequestDto param, Guid id = default) =>
        new(id)
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

    public static UpdateMotorcycleRequestDto ToUpdateDto(Guid id, string plate) =>
        new()
        {
            Id = id,
            Plate = plate
        };
}