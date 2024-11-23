using MotoXShare.Application.Domain.Enums;

namespace MotoXShare.Application.Domain.Model;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public UserRoles Role { get; set; }
}