using Microsoft.EntityFrameworkCore;
using MotoXShare.Application.Data.Context;
using MotoXShare.Application.Domain.Model;
using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Rentals;

public class RentalRepository(ApplicationContext context)
    : RepositoryAsync<Rental>(context), IRentalRepository
{
    public async Task<bool> CheckIfMotorcycleIsRented(Guid motorcycleId) =>
        await DbSet.AsNoTracking().AnyAsync(r => r.MotorcycleId == motorcycleId);

    public async Task<bool> CheckActiveRentalByDeliveryRiderId(Guid deliveryRiderId) =>
        await DbSet.AsNoTracking().AnyAsync(r => r.DeliveryRiderId == deliveryRiderId);
}