using MotoXShare.Domain.Base;

namespace MotoXShare.Domain.Model;

public class User(Guid id) : BaseEntity(id)
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public bool IsAdmin { get; set; }
}