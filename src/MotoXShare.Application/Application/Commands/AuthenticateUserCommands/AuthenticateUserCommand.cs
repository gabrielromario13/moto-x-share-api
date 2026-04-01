using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;

namespace MotoXShare.Core.Application.Commands.AuthenticateUserCommands;

public record AuthenticateUserCommand(string Username, string Password)
    : IRequest<ResultViewModel<AuthenticateUserViewModel>>;