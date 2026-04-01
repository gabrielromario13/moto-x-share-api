using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;

namespace MotoXShare.Core.Application.Commands.MotorcycleCommands;

public class UpdateMotorcycleCommandHandler(AppDbContext context)
    : IRequestHandler<UpdateMotorcycleCommand, ResultViewModel>
{
    public virtual async Task<ResultViewModel> Handle(
        UpdateMotorcycleCommand request,
        CancellationToken token)
    {
        var motorcycle = await context.Motorcycles.FirstOrDefaultAsync(m => m.Id == request.Id);

        if (motorcycle is null)
            return ResultViewModel.Error("Moto não encontrada.");

        motorcycle.Plate = request.Plate;

        context.Motorcycles.Update(motorcycle);
        await context.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}