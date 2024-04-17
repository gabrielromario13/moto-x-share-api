using MotoXShare.Domain.Base;

namespace MotoXShare.Domain.Model;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}