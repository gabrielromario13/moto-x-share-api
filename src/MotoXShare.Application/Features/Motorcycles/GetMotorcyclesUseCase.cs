using System.Linq.Expressions;
using MotoXShare.Application.Domain.Model;

namespace MotoXShare.Application.Features.Motorcycles;

public class GetMotorcyclesUseCase(IMotorcycleRepository repository)
{
    public virtual async Task<IEnumerable<GetMotorcycleResponseDto>> Action(
        Expression<Func<Motorcycle, bool>> param = null)
    {
        var motorcyclesDb = await repository.Get(param);

        var motorcycles = motorcyclesDb.Select(MotorcycleAdapter.FromDomain);

        return motorcycles.Any() ? motorcycles : [];
    }
}