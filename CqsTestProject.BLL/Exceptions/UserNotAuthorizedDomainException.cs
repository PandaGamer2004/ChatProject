namespace Chat.BLL.Exceptions;

public class UserNotAuthorizedDomainException : Exception
{
    public UserNotAuthorizedDomainException(string? message) : base(message)
    {
        
    }

    public UserNotAuthorizedDomainException() : base()
    {
        
    }
}