using MotoXShare.Application.Domain.Model;
using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Users;

public interface IUserRepository : IRepositoryAsync<User>
{
}