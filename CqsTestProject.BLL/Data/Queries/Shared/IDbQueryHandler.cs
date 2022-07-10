namespace Chat.BLL.Data.Queries.Shared;

public interface IDbQueryHandler<TDbQuery, TResult>
where TDbQuery : IDbQuery<TResult>
{
    Task<TResult> ExecuteQueryAsync(TDbQuery query);
}