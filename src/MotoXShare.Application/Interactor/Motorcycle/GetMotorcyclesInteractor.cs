using Microsoft.IdentityModel.Tokens;
using MotoXShare.Application.Interactor.Interface;
using MotoXShare.Application.UseCase.Motorcycle;
using MotoXShare.Domain.Dto.Motorcycle;
using MotoXShare.Infraestructure.UnitOfWork;
using System.Linq.Expressions;

namespace MotoXShare.Application.Interactor.Motorcycle;

public class GetMotorcyclesInteractor(
    EntityFrameworkUnitOfWorkAsync unitOfWork,
    GetMotorcyclesUseCase getMotorcyclesUseCase
) : InteractorAsync<IEnumerable<GetMotorcycleResponseDto>, GetMotorcycleRequestDto>(unitOfWork), IGetMotorcyclesInteractor
{
    private readonly GetMotorcyclesUseCase _getMotorcyclesUseCase = getMotorcyclesUseCase;

    protected override async Task<IEnumerable<GetMotorcycleResponseDto>> Action(GetMotorcycleRequestDto param)
    {
        var expression = GetExpression(param);

        return await _getMotorcyclesUseCase.Action(expression);
    }

    private static Expression<Func<Domain.Model.Motorcycle, bool>> GetExpression(GetMotorcycleRequestDto param)
    {
        return x =>
            param.Plate.IsNullOrEmpty() || param.Plate == x.Plate;
    }
}