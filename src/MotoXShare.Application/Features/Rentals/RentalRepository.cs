using Microsoft.EntityFrameworkCore;
using MotoXShare.Application.Features.Common;
using MotoXShare.Core.Data.Context;
using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Application.Features.Rentals;

public class RentalRepository(AppDbContext context)
    : RepositoryAsync<Rental>(context), IRentalRepository
{
    public async Task<bool> CheckIfMotorcycleIsRented(Guid motorcycleId) =>
        await DbSet.AsNoTracking().AnyAsync(r => r.MotorcycleId == motorcycleId);

    public async Task<bool> CheckActiveRentalByDeliveryRiderId(Guid deliveryRiderId) =>
        await DbSet.AsNoTracking().AnyAsync(r => r.DeliveryRiderId == deliveryRiderId);
}