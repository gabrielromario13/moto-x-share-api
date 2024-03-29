namespace MotoXShare.Domain.Dto.User;

public class SaveUserRequestDto
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsAdmin { get; set; }
}