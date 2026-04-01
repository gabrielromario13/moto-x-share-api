using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoXShare.Core.Application.Models.ViewModels;
using MotoXShare.Core.Data.Context;

namespace MotoXShare.Core.Application.Queries.MotorcycleQueries;

public class GetMotorcycleByPlateQueryHandler(AppDbContext context)
    : IRequestHandler<GetMotorcycleByPlateQuery, ResultViewModel<MotorcycleViewModel>>
{
    public async Task<ResultViewModel<MotorcycleViewModel>> Handle(
        GetMotorcycleByPlateQuery query,
        CancellationToken token)
    {
        var motorcycles = await context.Motorcycles
            .AsNoTracking().FirstOrDefaultAsync(m => m.Plate == query.Plate);

        return motorcycles is null ?
            ResultViewModel<MotorcycleViewModel>.Error("Moto não encontrada.") :
            ResultViewModel<MotorcycleViewModel>.Success(MotorcycleViewModel.FromEntity(motorcycles));
    }
}