using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Context;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Infraestructure.Data.Repository;

public class MotorcycleRepository(ApplicationContext context)
    : RepositoryAsync<Motorcycle>(context), IMotorcycleRepository
{
}