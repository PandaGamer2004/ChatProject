using Chat.BLL.BLL.Queries.GetChats.QueryModels;
using Chat.BLL.Data.Queries.GetChatsWithUserId;
using Chat.BLL.Data.Queries.Shared;
using Chat.BLL.Models;
using Chat.BLL.Queries.Shared;
using Chat.BLL.Utils;

namespace Chat.BLL.BLL.Queries.GetChats.Handlers;

public class GetAllChatsQueryHandler : IQueryHandler<GetAllChatsQuery, IEnumerable<ChatModel>>
{
    private readonly IUserInfoAccessor _userInfoAccessor;
 
    private readonly IDbQueryHandler<GetChatsWithUserIdDbQuery, IEnumerable<ChatModel>> _getChatsHandler;

    public GetAllChatsQueryHandler(IUserInfoAccessor userInfoAccessor,
        IDbQueryHandler<GetChatsWithUserIdDbQuery, IEnumerable<ChatModel>> getChatsHandler)
    {
        _userInfoAccessor = userInfoAccessor;
        _getChatsHandler = getChatsHandler;
    }
    public async Task<IEnumerable<ChatModel>> HandleQueryAsync(GetAllChatsQuery query)
    {
        var currentUserId = _userInfoAccessor.GetAuthenticatedUserId();
        var userChats = 
            await _getChatsHandler.ExecuteQueryAsync(new GetChatsWithUserIdDbQuery
            {
                UserId = currentUserId
            });
        return userChats;
    }
}
