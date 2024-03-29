using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Data.Repository.Base;

namespace MotoXShare.Infraestructure.Data.Repository.Interface;

public interface IUserRepository : IRepositoryAsync<User>
{
}