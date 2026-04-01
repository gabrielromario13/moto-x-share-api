using MediatR;
using MotoXShare.Core.Application.Models.ViewModels;

namespace MotoXShare.Core.Application.Queries.MotorcycleQueries;

public record GetMotorcycleByPlateQuery(string Plate)
    : IRequest<ResultViewModel<MotorcycleViewModel>>;