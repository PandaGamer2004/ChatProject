namespace Chat.BLL.Exceptions;

public class UserAuthorizedWithIncompleteClaimsSetDomainException : Exception
{
    public UserAuthorizedWithIncompleteClaimsSetDomainException() : base()
    {
        
    }

    public UserAuthorizedWithIncompleteClaimsSetDomainException(string? message) : base(message)
    {

    }

}