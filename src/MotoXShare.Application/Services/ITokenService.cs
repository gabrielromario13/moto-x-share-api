using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Core.Services;

public interface ITokenService
{
    string GenerateToken(User dto);
}