using Microsoft.EntityFrameworkCore;
using MotoXShare.Application.Data.Context;
using MotoXShare.Application.Domain.Enums;
using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.DeliveryRiders;

public class DeliveryRiderRepository
    : RepositoryAsync<Domain.Model.DeliveryRider>, IDeliveryRiderRepository
{
    private readonly IQueryable<Domain.Model.DeliveryRider> _query;

    public DeliveryRiderRepository(ApplicationContext context)
        : base(context)
    {
        _query = DbSet.AsNoTracking();
    }

    public async Task<bool> CheckIfCnpjExists(string cnpj) =>
        await _query.AnyAsync(d => d.CNPJ == cnpj);

    public async Task<bool> CheckIfCnhExists(string cnh) =>
        await _query.AnyAsync(d => d.CNH == cnh);

    public async Task<bool> CheckIfCnhTypeIsValid(Guid id) =>
         await _query.AnyAsync(d => d.Id == id && (d.CNHType == CnhTypes.A || d.CNHType == CnhTypes.AB));
}