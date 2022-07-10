using System.Data;
using Chat.BLL.Data.Queries.GetChatsWithUserId;
using Chat.BLL.Data.Queries.Shared;
using Chat.BLL.Models;
using Dapper;

namespace Chat.DAL.Queries.GetUsersWithUserId;

public class GetAllChatWithUserIdQueryHandler : IDbQueryHandler<GetChatsWithUserIdDbQuery, IEnumerable<ChatModel>>
{
    private readonly IDbConnection _connection;
    private const String StoredProcedureName = "[dbo].[getChatsWithUserId]";
    private const String UserIdParamName = "@userID";
    public GetAllChatWithUserIdQueryHandler(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public async Task<IEnumerable<ChatModel>> ExecuteQueryAsync(GetChatsWithUserIdDbQuery query)
    {
        
        var storedProcedureParams = new DynamicParameters();
        storedProcedureParams.Add(UserIdParamName,
            dbType:DbType.Int32,
            direction:ParameterDirection.Input);
        return await _connection.QueryAsync<ChatModel>(StoredProcedureName,
            storedProcedureParams,
            commandType: CommandType.StoredProcedure);
    }
    

}