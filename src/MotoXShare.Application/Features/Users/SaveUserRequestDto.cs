﻿namespace MotoXShare.Application.Features.Users;

public class SaveUserRequestDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Role { get; set; }
}