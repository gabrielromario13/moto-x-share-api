using MotoXShare.Domain.Base;

namespace MotoXShare.Domain.Model;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
}