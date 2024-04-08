namespace MotoXShare.Infraestructure.UnitOfWork.Base;

public abstract class UnitOfWorkAsync : IUnitOfWorkAsync
{
    protected UnitOfWorkAsync()
    {
    }

    public Task BeginUnitAsync() =>
        OnBeginUnitAsync();

    public Task CommitUnitAsync() =>
        OnCommitUnitAsync();

    public Task RollbackUnitAsync() =>
        OnRollbackUnitAsync();


    protected abstract Task OnBeginUnitAsync();
    protected abstract Task OnCommitUnitAsync();
    protected abstract Task OnRollbackUnitAsync();
}
