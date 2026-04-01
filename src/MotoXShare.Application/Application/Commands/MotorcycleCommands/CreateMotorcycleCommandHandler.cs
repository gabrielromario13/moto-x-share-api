using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;

namespace MotoXShare.Core.Application.Commands.MotorcycleCommands;

public class CreateMotorcycleCommandHandler(AppDbContext context)
    : IRequestHandler<CreateMotorcycleCommand, ResultViewModel<int>>
{
    public virtual async Task<ResultViewModel<int>> Handle(
        CreateMotorcycleCommand request,
        CancellationToken token)
    {
        var motorcycle = request.ToEntity();

        await context.Motorcycles.AddAsync(motorcycle, token);
        context.SaveChanges();

        return ResultViewModel<int>.Success(motorcycle.Id);
    }
}