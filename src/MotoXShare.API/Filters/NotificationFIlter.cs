using Microsoft.AspNetCore.Mvc.Filters;
using MotoXShare.Domain.Notification;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MotoXShare.API.Filters;

public class NotificationFilter(NotificationHandler notification)
    : IAsyncResultFilter
{
    private readonly NotificationHandler _notification = notification;

    public async Task OnResultExecutionAsync(
        ResultExecutingContext context,
        ResultExecutionDelegate next)
    {
        var instance = context.HttpContext.Request.Path.Value;

        var trace = context.HttpContext.TraceIdentifier;

        if (!context.ModelState.IsValid)
        {
            foreach (var key in context.ModelState.Keys)
            {
                var modelState = context.ModelState[key];

                if (modelState is not null)
                {
                    var error = string.Join(',', modelState.Errors.Select(c => c.ErrorMessage));

                    _notification.Add(new Notification(error, key));
                }
            }

            var response = SerializeResponse(instance!, trace);
            await ResponseContext(context, response);

            return;
        }

        if (_notification.HasNotification())
        {
            var response = SerializeResponse(instance!, trace);
            await ResponseContext(context, response);

            return;
        }

        await next();
    }

    private string SerializeResponse(string instance, string trace)
    {
        var content = _notification.GetAllErrorsResponse(instance, trace);

        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var result = JsonSerializer.Serialize(content, options);

        return result;
    }

    private static async Task ResponseContext(ResultExecutingContext context, string content)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.HttpContext.Response.ContentType = "application/problem+json";
        await context.HttpContext.Response.WriteAsync(content);
    }
}