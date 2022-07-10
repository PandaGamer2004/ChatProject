using Chat.BLL.BLL.Queries.GetChats.Handlers;
using Chat.BLL.BLL.Queries.GetChats.QueryModels;
using Chat.BLL.Data.Queries.GetChatsWithUserId;
using Chat.BLL.Data.Queries.Shared;
using Chat.BLL.Models;
using Chat.BLL.Queries.Shared;
using Chat.DAL.Queries.GetUsersWithUserId;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IQueryHandler<GetAllChatsQuery, IEnumerable<ChatModel>>, GetAllChatsQueryHandler>();
builder.Services.AddScoped<IDbQueryHandler<GetChatsWithUserIdDbQuery, IEnumerable<ChatModel>>, GetAllChatWithUserIdQueryHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();