using Chat.BLL.BLL.Queries.GetChats.QueryModels;
using Chat.BLL.Models;
using Chat.BLL.Queries.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Chat.API.Controllers;


public class ChatsController : BaseApiController
{ 
    private IQueryHandler<GetAllChatsQuery, IEnumerable<ChatModel>> _getChatsQueryHandler;

    public ChatsController(IQueryHandler<GetAllChatsQuery, IEnumerable<ChatModel>> getChatsQueryHandler)
    {
        _getChatsQueryHandler = getChatsQueryHandler;
    }

    [HttpGet(Name = "GetAllChats")]
    [ProducesResponseType(typeof(ChatModel[]), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(typeof(IDictionary<string, string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllChats()
    {
        var chats = await _getChatsQueryHandler.HandleQueryAsync(new GetAllChatsQuery());
        return Ok(chats);
    }
}