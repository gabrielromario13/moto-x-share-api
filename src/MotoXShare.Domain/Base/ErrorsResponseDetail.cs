namespace MotoXShare.Domain.Base;

public sealed class ErrorsResponseDetail(string type, string error, string detail)
{
    public string Type { get; set; } = type;
    public string Error { get; set; } = error;
    public string Detail { get; set; } = detail;
}