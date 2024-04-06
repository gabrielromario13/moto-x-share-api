using MotoXShare.Domain.Dto.User;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

public static class UserAdapter
{
    public static User ToDomain(SaveUserRequestDto param, Guid id = default) =>
        new(id)
        {
            FullName = param.FullName,
            BirthDate = param.BirthDate,
            Email = param.Email,
            Password = param.Password,
            IsAdmin = param.IsAdmin
        };
}