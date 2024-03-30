using Microsoft.EntityFrameworkCore;
using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Context;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Infraestructure.Data.Repository;

public class RentalRepository(ApplicationContext context)
    : RepositoryAsync<Rental>(context), IRentalRepository
{
    public async Task<bool> CheckIfMotorcycleIsRented(Guid motorcycleId) =>
        await _dbSet.AsNoTracking().AnyAsync(r => r.MotorcycleId == motorcycleId);
}