using MotoXShare.Application.Adapter;
using MotoXShare.Domain.Dto.User;
using MotoXShare.Infraestructure.Data.Repository.Interface;

namespace MotoXShare.Application.UseCase.User;

public class SaveUserUseCase(IUserRepository repository)
{
    public virtual async Task<Guid> Action(SaveUserRequestDto param)
    {
        var user = UserAdapter.ToDomain(param);

        await repository.Add(user);

        return user.Id;
    }
}