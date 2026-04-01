using System.Text.Json.Serialization;

namespace MotoXShare.Core.Application.Models.ViewModels;

public record ResultViewModel(
    [property: JsonIgnore]bool IsSuccess = true,
    string Message = "")
{
    public static ResultViewModel Success() => new();
    public static ResultViewModel Error(string message)
        => new(false, message);
}

public record ResultViewModel<T>(
    T Data,
    bool IsSuccess = true,
    string Message = ""
) : ResultViewModel(IsSuccess, Message)
{
    public static ResultViewModel<T> Success(T data, string message = "")
        => new(data, Message: message);

    public new static ResultViewModel<T> Error(string message)
        => new(default, false, message);
}