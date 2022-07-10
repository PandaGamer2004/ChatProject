namespace Chat.BLL.Utils;

public interface IUserInfoAccessor
{
    public Guid GetAuthenticatedUserId();
}