using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.Motorcycle;
using MotoXShare.Infraestructure.Data.Repository.Interface;
using System.Linq.Expressions;

namespace MotoXShare.Application.UseCase.Motorcycle;

public class GetMotorcyclesUseCase(IMotorcycleRepository repository)
{
    public virtual async Task<IEnumerable<GetMotorcycleResponseDto>> Action(
        Expression<Func<Domain.Model.Motorcycle, bool>> param = null)
    {
        var motorcyclesDb = await repository.Get(param);

        var motorcycles = motorcyclesDb.Select(MotorcycleAdapter.FromDomain);

        return motorcycles.Any() ? motorcycles : [];
    }
}