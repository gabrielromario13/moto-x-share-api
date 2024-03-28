using MotoXShare.Domain.Base;

namespace MotoXShare.Domain.Model;

public class User(Guid id) : BaseEntity(id)
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsAdmin { get; set; }
}
