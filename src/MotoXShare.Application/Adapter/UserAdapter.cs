using MotoXShare.Domain.Dto.User;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

public static class UserAdapter
{
    public static User ToDomain(SaveUserRequestDto param, Guid id = default) =>
        new(id)
        {
            Name = param.Name,
            BirthDate = param.BirthDate,
            IsAdmin = param.IsAdmin
        };
}