using MotoXShare.Domain.Dto.User;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Adapter;

public static class UserAdapter
{
    public static User ToDomain(SaveUserRequestDto param) =>
        new()
        {
            FullName = param.FullName,
            Username = param.Username,
            Email = param.Email,
            Password = param.Password,
            Role = param.Role
        };

    public static GetUserResponseDto FromDomain(User param, string token = default) =>
        new()
        {
            FullName = param.FullName,
            Username = param.Username,
            Email = param.Email,
            Role = param.Role,
            Token = token
        };
}