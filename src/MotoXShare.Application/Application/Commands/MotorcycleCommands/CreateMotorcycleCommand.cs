using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Core.Application.Commands.MotorcycleCommands;

public record CreateMotorcycleCommand(
    short Year,
    string Model,
    string Plate
) : IRequest<ResultViewModel<int>>
{
    public Motorcycle ToEntity() =>
        new(Year, Model, Plate);
}