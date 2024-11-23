namespace MotoXShare.Application.Domain.Base;

public abstract class BaseError(string instance, string traceId)
{
    public string Instance { get; set; } = instance;
    public string TraceId { get; set; } = traceId;
}