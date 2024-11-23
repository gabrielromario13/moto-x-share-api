﻿namespace MotoXShare.Application.Features.Notifications;

public sealed class Notification(string detail, string error)
{
    public string Detail { get; private set; } = detail;
    public string Error { get; private set; } = error;
}