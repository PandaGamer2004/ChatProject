CREATE OR ALTER PROCEDURE [dbo].[getChatsWithUserId]
(@userID uniqueidentifier)
AS
BEGIN
SELECT TOP 1 chatId, chatName, userId
FROM [dbo].[Chats] as Ch
INNER JOIN [dbo].[ChatUsers] as Cu 
    ON Ch.chatId = Cu.chatId
    AND Cu.userId = @userID
END