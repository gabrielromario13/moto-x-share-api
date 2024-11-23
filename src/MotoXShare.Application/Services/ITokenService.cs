using MotoXShare.Application.Domain.Model;

namespace MotoXShare.Application.Services;

public interface ITokenService
{
    string GenerateToken(User dto);
}