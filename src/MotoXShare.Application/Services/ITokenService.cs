using MotoXShare.Domain.Dto.User;
using MotoXShare.Domain.Model;

namespace MotoXShare.Application.Services;

public interface ITokenService
{
    string GenerateToken(User dto);
}