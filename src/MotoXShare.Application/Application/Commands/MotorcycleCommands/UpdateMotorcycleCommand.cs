using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;

namespace MotoXShare.Core.Application.Commands.MotorcycleCommands;

public record UpdateMotorcycleCommand(int Id, string Plate) : IRequest<ResultViewModel>;