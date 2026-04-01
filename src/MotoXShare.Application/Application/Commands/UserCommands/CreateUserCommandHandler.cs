using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;

namespace MotoXShare.Core.Application.Commands.UserCommands;

public class CreateUserCommandHandler(AppDbContext context)
    : IRequestHandler<CreateUserCommand, ResultViewModel<int>>
{
    public virtual async Task<ResultViewModel<int>> Handle(
        CreateUserCommand request,
        CancellationToken token)
    {
        var user = request.ToEntity();

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return ResultViewModel<int>.Success(user.Id);
    }
}