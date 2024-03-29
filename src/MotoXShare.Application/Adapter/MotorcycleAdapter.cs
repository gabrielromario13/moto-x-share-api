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
}