using MotoXShare.Application.Data.Context;
using MotoXShare.Application.Features.Common;

namespace MotoXShare.Application.Features.Users;

public class UserRepository(ApplicationContext context)
    : RepositoryAsync<Domain.Model.User>(context), IUserRepository
{
}