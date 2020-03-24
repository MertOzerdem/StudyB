CREATE TABLE [dbo].[Messages] (
    [Id]          UNIQUEIDENTIFIER   NOT NULL,
    [Text]        NVARCHAR (MAX)     NULL,
    [FileAddress] NVARCHAR (MAX)     NULL,
    [DateOfPost]  DATETIMEOFFSET (7) NOT NULL,
    [UserId]      UNIQUEIDENTIFIER   NOT NULL,
    [ChatroomId]  UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Messages_Chatrooms_ChatroomId] FOREIGN KEY ([ChatroomId]) REFERENCES [dbo].[Chatrooms] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Messages_ChatroomId]
    ON [dbo].[Messages]([ChatroomId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Messages_UserId]
    ON [dbo].[Messages]([UserId] ASC);

