namespace MotoXShare.Domain.Dto.User;

public class SaveUserRequestDto
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
}