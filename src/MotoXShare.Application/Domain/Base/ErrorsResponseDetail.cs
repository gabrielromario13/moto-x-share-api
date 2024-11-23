namespace MotoXShare.Application.Domain.Base;

public sealed class ErrorsResponseDetail(string error, string detail)
{
    public string Error { get; set; } = error;
    public string Detail { get; set; } = detail;
}