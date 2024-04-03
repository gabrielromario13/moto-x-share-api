using MotoXShare.Application.Interactor.Base;
using MotoXShare.Infraestructure.UnitOfWork.Base;

namespace MotoXShare.Application.Interactor;

public abstract class InteractorAsync<TResult, TParam>(
    IUnitOfWorkAsync unitOfWork
) : IInteractorAsync<TResult, TParam>
{
    private readonly IUnitOfWorkAsync _unitOfWork = unitOfWork;

    public async Task<TResult> Execute(TParam param)
    {
        await _unitOfWork.BeginUnitAsync();

        TResult result;

        try
        {
            result = await Action(param);
            await _unitOfWork.CommitUnitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackUnitAsync();
            throw;
        }

        return result;
    }

    protected abstract Task<TResult> Action(TParam param);
}