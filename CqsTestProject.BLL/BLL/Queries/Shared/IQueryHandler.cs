namespace Chat.BLL.Queries.Shared;

public interface IQueryHandler<in TQuery, TResult>
where TQuery : IQuery<TResult>
{
    public Task<TResult> HandleQueryAsync(TQuery query);
}