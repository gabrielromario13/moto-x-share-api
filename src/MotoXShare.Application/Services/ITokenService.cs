using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Application.Services;

public interface ITokenService
{
    string GenerateToken(User dto);
}