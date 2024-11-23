namespace MotoXShare.Application.Features.Common;

public interface IInteractorAsync<TResult, in TParam>
{
    Task<TResult> Execute(TParam param);
}