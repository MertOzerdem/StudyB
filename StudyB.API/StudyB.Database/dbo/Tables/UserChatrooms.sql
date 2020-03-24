CREATE TABLE [dbo].[UserChatrooms] (
    [ChatroomId] UNIQUEIDENTIFIER NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_UserChatrooms] PRIMARY KEY CLUSTERED ([ChatroomId] ASC, [UserId] ASC),
    CONSTRAINT [FK_UserChatrooms_Chatrooms_ChatroomId] FOREIGN KEY ([ChatroomId]) REFERENCES [dbo].[Chatrooms] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserChatrooms_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserChatrooms_UserId]
    ON [dbo].[UserChatrooms]([UserId] ASC);

