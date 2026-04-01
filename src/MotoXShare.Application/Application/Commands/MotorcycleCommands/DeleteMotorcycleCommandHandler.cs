using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;

namespace MotoXShare.Core.Application.Commands.MotorcycleCommands;

public class DeleteMotorcycleCommandHandler(AppDbContext context)
    : IRequestHandler<DeleteMotorcycleCommand, ResultViewModel>
{
    public virtual async Task<ResultViewModel> Handle(
        DeleteMotorcycleCommand request,
        CancellationToken token)
    {
        var motorcycle = await context.Motorcycles
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (motorcycle is null)
            return ResultViewModel.Error(string.Empty);

        var rentedMotorcycle = await context.Rentals
            .AsNoTracking()
            .AnyAsync(r => r.MotorcycleId == request.Id);

        if (rentedMotorcycle)
            return ResultViewModel.Error("Moto com locação ativa. Não foi possível realizar exclusão.");

        context.Motorcycles.Remove(motorcycle);
        await context.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}
