using MotoXShare.Application.Features.Common;
using MotoXShare.Core.Data.Context;
using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Application.Features.Users;

public class UserRepository(AppDbContext context)
    : RepositoryAsync<User>(context), IUserRepository
{
}