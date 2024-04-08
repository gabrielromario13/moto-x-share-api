namespace MotoXShare.Domain.Base;

public sealed class ErrorsResponseDetail(string error, string detail)
{
    public string Error { get; set; } = error;
    public string Detail { get; set; } = detail;
}