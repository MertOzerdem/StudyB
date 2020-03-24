CREATE TABLE [dbo].[Rewards] (
    [Id]     INT              IDENTITY (1, 1) NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Rewards] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Rewards_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Rewards_UserId]
    ON [dbo].[Rewards]([UserId] ASC);

