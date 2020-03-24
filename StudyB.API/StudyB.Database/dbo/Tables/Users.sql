CREATE TABLE [dbo].[Users] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [UserName]  NVARCHAR (MAX)   NULL,
    [FirstName] NVARCHAR (MAX)   NULL,
    [LastName]  NVARCHAR (MAX)   NULL,
    [Password]  NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

