namespace Work360.Services.Notification.Application.Exceptions;

public abstract class ApplicationException(string message) : Exception(message)
{
    public virtual string Code { get; }
}