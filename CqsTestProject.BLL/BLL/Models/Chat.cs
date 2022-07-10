namespace Chat.BLL.Models;

public class ChatModel : IModel
{
    public Guid ChatId { get; set; }
    
    public String ChatName { get; set; }
    
    public Guid ChatUserId { get; set; }
}