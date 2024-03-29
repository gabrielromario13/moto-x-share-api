namespace MotoXShare.Application.Interactor.Base;

public interface IInteractorAsync<TResult, in TParam>
{
    Task<TResult> Execute(TParam param);
}