using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Core.Application.Models.ViewModels;

public record AuthenticateUserViewModel(
    string FullName,
    string Username,
    string Email,
    string Role,
    string Token)
{
    public static AuthenticateUserViewModel FromEntity(User user, string token = default) =>
        new(user.FullName,
            user.Username,
            user.Email,
            user.Role.ToString(),
            token);
}