namespace Work360.Services.Notification.Core.Exceptions;

public class InvalidEmailException(string email) : DomainException($"Email address {email} is invalid")
{
    public override string Code { get; } = "invalid_email_address";
}