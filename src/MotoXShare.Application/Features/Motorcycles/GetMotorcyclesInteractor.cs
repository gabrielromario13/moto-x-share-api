using System.Linq.Expressions;
using Microsoft.IdentityModel.Tokens;
using MotoXShare.Application.Domain.Model;
using MotoXShare.Application.Features.Common;
using MotoXShare.Application.UnitOfWork;

namespace MotoXShare.Application.Features.Motorcycles;

public class GetMotorcyclesInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    GetMotorcyclesUseCase getMotorcyclesUseCase
) : InteractorAsync<IEnumerable<GetMotorcycleResponseDto>, GetMotorcycleRequestDto>(unitOfWork), IGetMotorcyclesInteractor
{
    protected override async Task<IEnumerable<GetMotorcycleResponseDto>> Action(GetMotorcycleRequestDto param)
    {
        var expression = GetExpression(param);

        return await getMotorcyclesUseCase.Action(expression);
    }

    private static Expression<Func<Motorcycle, bool>> GetExpression(GetMotorcycleRequestDto param)
    {
        return x =>
            param.Plate.IsNullOrEmpty() || param.Plate == x.Plate;
    }
}