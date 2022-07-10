using System.Security.Claims;
using Chat.BLL.Exceptions;
using Chat.BLL.Utils;

namespace Chat.API.Utils;


public class UserInfoAccessor : IUserInfoAccessor
{
    private HttpContextAccessor _accessor;

    public UserInfoAccessor(HttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    
    public Guid GetAuthenticatedUserId()
    {
        var currentUser = GetCurrentUser();
        var userIdClaim = GetRequestedClaimOrThrowError(user: currentUser, claimType: "user_id");
        return Guid.Parse(userIdClaim.Value);
    }

    //TODO Think about adding own custom claim types
    
    //TODO Important
    private Claim GetRequestedClaimOrThrowError(ClaimsPrincipal user, string claimType)
    {
        var userClaimValue = user.Claims.FirstOrDefault(claim => claim.Type == claimType);
        return userClaimValue 
               ?? throw new UserAuthorizedWithIncompleteClaimsSetDomainException($"Required claim: {claimType}");
    }

    private ClaimsPrincipal GetCurrentUser()
        => _accessor.HttpContext?.User 
           ?? throw new UserNotAuthorizedDomainException();
}