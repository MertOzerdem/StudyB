CREATE TABLE [dbo].[Chatrooms] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [ChatroomName] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Chatrooms] PRIMARY KEY CLUSTERED ([Id] ASC)
);

