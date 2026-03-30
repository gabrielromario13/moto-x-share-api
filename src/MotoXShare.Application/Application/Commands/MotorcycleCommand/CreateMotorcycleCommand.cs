using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Core.Application.Commands.MotorcycleCommand;

public class CreateMotorcycleCommand : IRequest<ResultViewModel<int>>
{
    public short Year { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }

    public Motorcycle ToEntity() =>
        new(Year, Model, Plate);
}