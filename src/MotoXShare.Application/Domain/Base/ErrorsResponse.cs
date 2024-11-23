namespace MotoXShare.Application.Domain.Base;

public sealed class ErrorsResponse(
    string instance,
    string traceId,
    IEnumerable<ErrorsResponseDetail> errors
) : BaseError(instance, traceId)
{
    public IEnumerable<ErrorsResponseDetail> Errors { get; set; } = errors;
}