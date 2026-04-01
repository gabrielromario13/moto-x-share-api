using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Domain.Entities;
using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Application.Commands.UserCommands;

public record CreateUserCommand(
    string FullName,
    string Email,
    string Username,
    string Password,
    int Role) : IRequest<ResultViewModel<int>>
{
    public User ToEntity() =>
        new(FullName, Email, Username, Password, (UserRoles)Role);
}