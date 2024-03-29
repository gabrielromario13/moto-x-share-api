namespace MotoXShare.Infraestructure.UnitOfWork.Base;

public interface IUnitOfWorkAsync
{
    Task BeginUnitAsync();

    Task CommitUnitAsync();

    Task RollbackUnitAsync();
}
