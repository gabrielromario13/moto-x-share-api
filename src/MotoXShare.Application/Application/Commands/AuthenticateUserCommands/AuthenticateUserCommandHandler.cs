using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoXShare.Application.Hash;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;
using MotoXShare.Core.Services;

namespace MotoXShare.Core.Application.Commands.AuthenticateUserCommands;

public class AuthenticateUserCommandHandler(
    AppDbContext context,
    ITokenService tokenService
) : IRequestHandler<AuthenticateUserCommand, ResultViewModel<AuthenticateUserViewModel>>
{
    public virtual async Task<ResultViewModel<AuthenticateUserViewModel>> Handle(
        AuthenticateUserCommand command,
        CancellationToken cancellationToken)
    {
        var password = HashUtils.HashPassword(command.Password);

        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Username == command.Username &&
                                      x.Password == password);

        if (user is null)
            return ResultViewModel<AuthenticateUserViewModel>.Error("Usuário não encontrado.");

        var token = tokenService.GenerateToken(user);

        return ResultViewModel<AuthenticateUserViewModel>
            .Success(AuthenticateUserViewModel.FromEntity(user, token));
    }
}