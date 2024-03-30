using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Context;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Infraestructure.Data.Repository;

public class UserRepository(ApplicationContext context) 
    : RepositoryAsync<User>(context), IUserRepository
{
}