using Microsoft.EntityFrameworkCore;
using MotoXShare.Domain.Enums;
using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Context;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Infraestructure.Data.Repository;

public class DeliveryRiderRepository
    : RepositoryAsync<DeliveryRider>, IDeliveryRiderRepository
{
    private readonly IQueryable<DeliveryRider> _query;

    public DeliveryRiderRepository(ApplicationContext context)
        : base(context)
    {
        _query = _dbSet.AsNoTracking();
    }

    public async Task<bool> CheckIfCnpjExists(string cnpj) =>
        await _query.AnyAsync(d => d.CNPJ == cnpj);

    public async Task<bool> CheckIfCnhExists(string cnh) =>
        await _query.AnyAsync(d => d.CNH == cnh);

    public async Task<bool> CheckIfCnhTypeIsValid(Guid id) =>
         await _query.AnyAsync(d => d.Id == id && (d.CNHType == CnhTypes.A || d.CNHType == CnhTypes.AB));
}