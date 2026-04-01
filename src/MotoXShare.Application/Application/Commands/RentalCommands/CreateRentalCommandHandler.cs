using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoXShare.Application.Features.Notifications;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;
using MotoXShare.Core.Domain.Entities;
using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Application.Commands.RentalCommands;

public class CreateRentalCommandHandler(
    AppDbContext context,
    NotificationHandler notificationHandler
) : IRequestHandler<CreateRentalCommand, ResultViewModel<int>>
{
    public virtual async Task<ResultViewModel<int>> Handle(
        CreateRentalCommand request,
        CancellationToken token)
    {
        var motorcycle = await context.Motorcycles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => !x.Rented);

        await ValidateRentalRequirements(motorcycle, request.DeliveryRiderId);

        if (notificationHandler.HasNotification())
            return ResultViewModel<int>.Error(default);

        var rental = request.ToEntity(motorcycle.Id);

        context.Rentals.Add(rental);
        await context.SaveChangesAsync();

        motorcycle.ToggleRented();
        context.Motorcycles.Update(motorcycle);
        await context.SaveChangesAsync();

        return ResultViewModel<int>.Success(rental.Id);
    }

    private async Task ValidateRentalRequirements(Motorcycle motorcycle, int deliveryRiderId)
    {
        if (motorcycle is null)
            notificationHandler.Add(new("Nenhuma moto disponível para locação.", "NoMotorcyclesAvailable"));

        var validCnhType = await context.DeliveryRiders
            .AnyAsync(d => d.Id == deliveryRiderId && (d.CNHType == CnhTypes.A || d.CNHType == CnhTypes.AB));
        
        if (!validCnhType)
            notificationHandler.Add(new("Tipo de CNH inválido.", "InvalidCnhType"));

        var activeRental = await context.Rentals
            .AsNoTracking()
            .AnyAsync(r => r.DeliveryRiderId == deliveryRiderId);
        
        if (activeRental)
            notificationHandler.Add(new("Você já possui um plano de locação ativo.", "ActiveRental"));
    }
}