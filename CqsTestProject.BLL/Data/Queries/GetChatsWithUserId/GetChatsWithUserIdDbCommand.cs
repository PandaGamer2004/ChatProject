using Chat.BLL.Data.Queries.Shared;
using Chat.BLL.Models;

namespace Chat.BLL.Data.Queries.GetChatsWithUserId;

public class GetChatsWithUserIdDbQuery : IDbQuery<IEnumerable<ChatModel>>
{
    public Guid UserId { get; set; }
}