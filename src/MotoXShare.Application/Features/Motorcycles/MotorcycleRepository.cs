using MotoXShare.Application.Data.Context;
using MotoXShare.Application.Domain.Model;
using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Motorcycles;

public class MotorcycleRepository(ApplicationContext context)
    : RepositoryAsync<Motorcycle>(context), IMotorcycleRepository
{
}