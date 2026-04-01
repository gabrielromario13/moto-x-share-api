using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;

namespace MotoXShare.Core.Application.Commands.MotorcycleCommands;

public record DeleteMotorcycleCommand(int Id) : IRequest<ResultViewModel>;