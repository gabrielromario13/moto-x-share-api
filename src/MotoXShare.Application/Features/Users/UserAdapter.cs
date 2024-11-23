using MotoXShare.Application.Domain.Enums;
using MotoXShare.Application.Domain.Model;
using MotoXShare.Application.Hash;

namespace MotoXShare.Application.Features.Users;

public static class UserAdapter
{
    public static User ToDomain(SaveUserRequestDto param) =>
        new()
        {
            FullName = param.FullName,
            Username = param.Username,
            Email = param.Email,
            Password = HashUtils.HashPassword(param.Password),
            Role = (UserRoles)param.Role
        };

    public static GetUserResponseDto FromDomain(User param, string token = default) =>
        new()
        {
            FullName = param.FullName,
            Username = param.Username,
            Email = param.Email,
            Role = param.Role.ToString(),
            Token = token
        };
}