using MotoXShare.Application.Features.Common;
using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Application.Features.Users;

public interface IUserRepository : IRepositoryAsync<User>
{
}