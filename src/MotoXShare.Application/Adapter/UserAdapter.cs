using MotoXShare.Domain.Dto.User;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

public static class UserAdapter
{
    public static User ToDomain(SaveUserRequestDto param) =>
        new()
        {
            FullName = param.FullName,
            BirthDate = param.BirthDate
        };
}