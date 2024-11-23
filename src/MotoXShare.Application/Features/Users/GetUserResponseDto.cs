namespace MotoXShare.Application.Features.Users;

public class GetUserResponseDto
{
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}