namespace MotoXShare.Application.Features.Users;

public class SaveUserUseCase(IUserRepository repository)
{
    public virtual async Task<Guid> Action(SaveUserRequestDto param)
    {
        var user = UserAdapter.ToDomain(param);

        await repository.Add(user);

        return user.Id;
    }
}