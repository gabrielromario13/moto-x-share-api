namespace MotoXShare.Application.UnitOfWork.Base;

public interface IUnitOfWorkAsync
{
    Task BeginUnitAsync();

    Task CommitUnitAsync();

    Task RollbackUnitAsync();
}
