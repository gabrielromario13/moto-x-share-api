using MotoXShare.Data.Repository.Base;
using MotoXShare.Data.Repository.Interface;
using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Context;

namespace MotoXShare.Data.Repository;

public class UserRepository(ApplicationContext context) : RepositoryAsync<User>(context), IUserRepository
{
}