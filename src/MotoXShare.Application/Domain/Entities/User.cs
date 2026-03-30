using MotoXShare.Core.Domain.Enums;

namespace MotoXShare.Core.Domain.Entities;

public class User(string fullName, string email, string username, string password, UserRoles role) : BaseEntity
{
    public string FullName { get; set; } = fullName;
    public string Email { get; set; } = email;
    public string Username { get; set; } = username;
    public string Password { get; set; } = password;
    public UserRoles Role { get; set; } = role;
}