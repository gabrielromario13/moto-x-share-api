using MotoXShare.Application.Interactor.Base;
using MotoXShare.Infraestructure.UnitOfWork.Base;

namespace MotoXShare.Application.Interactor;

public abstract class InteractorAsync<TResult, TParam>(
    IUnitOfWorkAsync unitOfWork
) : IInteractorAsync<TResult, TParam>
{
    public async Task<TResult> Execute(TParam param)
    {
        await unitOfWork.BeginUnitAsync();

        TResult result;

        try
        {
            result = await Action(param);
            await unitOfWork.CommitUnitAsync();
        }
        catch
        {
            await unitOfWork.RollbackUnitAsync();
            throw;
        }

        return result;
    }

    protected abstract Task<TResult> Action(TParam param);
}