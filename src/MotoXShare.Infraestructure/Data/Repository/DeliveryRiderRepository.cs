using Microsoft.EntityFrameworkCore;
using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Context;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Infraestructure.Data.Repository;

public class DeliveryRiderRepository(ApplicationContext context)
    : RepositoryAsync<DeliveryRider>(context), IDeliveryRiderRepository
{
    public async Task<bool> CheckIfCnpjExists(string cnpj) =>
        await _dbSet.AsNoTracking().AnyAsync(d => d.CNPJ == cnpj);

    public async Task<bool> CheckIfCnhExists(string cnh) =>
        await _dbSet.AsNoTracking().AnyAsync(d => d.CNH == cnh);
}