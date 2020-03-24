IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    CREATE TABLE [Chatrooms] (
        [Id] uniqueidentifier NOT NULL,
        [ChatroomName] nvarchar(max) NULL,
        CONSTRAINT [PK_Chatrooms] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    CREATE TABLE [Users] (
        [Id] uniqueidentifier NOT NULL,
        [UserName] nvarchar(max) NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    CREATE TABLE [Messages] (
        [Id] uniqueidentifier NOT NULL,
        [Text] nvarchar(max) NULL,
        [FileAddress] nvarchar(max) NULL,
        [DateOfPost] datetimeoffset NOT NULL,
        [UserId] uniqueidentifier NOT NULL,
        [ChatroomId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Messages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Messages_Chatrooms_ChatroomId] FOREIGN KEY ([ChatroomId]) REFERENCES [Chatrooms] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Messages_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    CREATE TABLE [Rewards] (
        [Id] int NOT NULL IDENTITY,
        [UserId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Rewards] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Rewards_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    CREATE TABLE [UserChatrooms] (
        [ChatroomId] uniqueidentifier NOT NULL,
        [UserId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_UserChatrooms] PRIMARY KEY ([ChatroomId], [UserId]),
        CONSTRAINT [FK_UserChatrooms_Chatrooms_ChatroomId] FOREIGN KEY ([ChatroomId]) REFERENCES [Chatrooms] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserChatrooms_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ChatroomName') AND [object_id] = OBJECT_ID(N'[Chatrooms]'))
        SET IDENTITY_INSERT [Chatrooms] ON;
    INSERT INTO [Chatrooms] ([Id], [ChatroomName])
    VALUES ('1acf8e02-9be4-428a-bd6b-8dce083bfac3', N'Cs 492'),
    ('ce446daa-5e35-4f2a-ab83-cf75cac4837e', N'Cs 453'),
    ('c25ed015-3e14-440d-a7c0-7eeedc0cf32b', N'Morning Breeze');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ChatroomName') AND [object_id] = OBJECT_ID(N'[Chatrooms]'))
        SET IDENTITY_INSERT [Chatrooms] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName', N'Password', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    INSERT INTO [Users] ([Id], [FirstName], [LastName], [Password], [UserName])
    VALUES ('d28888e9-2ba9-473a-a40f-e38cb54f9b35', N'Pasta', N'Sempa', N'123', N'Pasta'),
    ('da2fd609-d754-4feb-8acd-c4f9ff13ba96', N'Pepe', N'Julian Onziema', N'159', N'LGBT Right Activist'),
    ('8ded4df7-4355-41b0-9b44-a9de574bcc48', N'Ismini', N'bulamadım', N'159', N'The Host');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName', N'Password', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ChatroomId', N'DateOfPost', N'FileAddress', N'Text', N'UserId') AND [object_id] = OBJECT_ID(N'[Messages]'))
        SET IDENTITY_INSERT [Messages] ON;
    INSERT INTO [Messages] ([Id], [ChatroomId], [DateOfPost], [FileAddress], [Text], [UserId])
    VALUES ('9bcfa927-179d-4346-a34e-e09928450456', '1acf8e02-9be4-428a-bd6b-8dce083bfac3', '1690-11-23T00:00:00.0000000+02:00', NULL, N'What is up?', 'd28888e9-2ba9-473a-a40f-e38cb54f9b35'),
    ('0936b9d0-c45a-4112-9306-fad95e9c07c7', '1acf8e02-9be4-428a-bd6b-8dce083bfac3', '1988-12-09T00:00:00.0000000+02:00', NULL, N'Mavi Tik', 'd28888e9-2ba9-473a-a40f-e38cb54f9b35'),
    ('74fa1016-b592-4948-b582-c163ddc8e5fa', 'c25ed015-3e14-440d-a7c0-7eeedc0cf32b', '2014-12-09T22:02:10.0000000+03:00', NULL, N'Who says I am gay?', 'da2fd609-d754-4feb-8acd-c4f9ff13ba96'),
    ('eab75a96-544a-480d-98dd-e375abaac938', 'c25ed015-3e14-440d-a7c0-7eeedc0cf32b', '2014-12-09T22:05:05.0000000+03:00', NULL, N'I am not ... active right now.', 'da2fd609-d754-4feb-8acd-c4f9ff13ba96'),
    ('9ca606d2-c909-46e6-ab6e-5f8616f083a6', 'c25ed015-3e14-440d-a7c0-7eeedc0cf32b', '2014-12-09T22:01:05.0000000+03:00', NULL, N'We are bringing the studio this morning one of the gay right activist, Mr... Should I call You Mista?', '8ded4df7-4355-41b0-9b44-a9de574bcc48'),
    ('d9292237-ad99-4347-a6a5-9eb12669e789', 'c25ed015-3e14-440d-a7c0-7eeedc0cf32b', '2014-12-09T22:02:05.0000000+03:00', NULL, N'Pepe Julian Onziema thank you for coming. Why are you gay?', '8ded4df7-4355-41b0-9b44-a9de574bcc48'),
    ('4cf3d108-2d49-4a76-a024-8a8d96fec24b', 'c25ed015-3e14-440d-a7c0-7eeedc0cf32b', '2014-12-09T22:03:05.0000000+03:00', NULL, N'You are Gay. You''re Transgenda, and gay rights activist, and outspoken lesbian?, Homosexual?', '8ded4df7-4355-41b0-9b44-a9de574bcc48'),
    ('176cdccd-5156-450a-b3ac-f7e33f1338bd', 'c25ed015-3e14-440d-a7c0-7eeedc0cf32b', '2014-12-09T22:04:05.0000000+03:00', NULL, N'Now we are looking at the debate. Why should someone be gay?', '8ded4df7-4355-41b0-9b44-a9de574bcc48'),
    ('88990eac-0974-45f0-afd5-5c3dae5ada75', 'c25ed015-3e14-440d-a7c0-7eeedc0cf32b', '2014-12-09T22:06:05.0000000+03:00', NULL, N'Doesn''t that make you gay?', '8ded4df7-4355-41b0-9b44-a9de574bcc48');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ChatroomId', N'DateOfPost', N'FileAddress', N'Text', N'UserId') AND [object_id] = OBJECT_ID(N'[Messages]'))
        SET IDENTITY_INSERT [Messages] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ChatroomId', N'UserId') AND [object_id] = OBJECT_ID(N'[UserChatrooms]'))
        SET IDENTITY_INSERT [UserChatrooms] ON;
    INSERT INTO [UserChatrooms] ([ChatroomId], [UserId])
    VALUES ('ce446daa-5e35-4f2a-ab83-cf75cac4837e', 'd28888e9-2ba9-473a-a40f-e38cb54f9b35'),
    ('ce446daa-5e35-4f2a-ab83-cf75cac4837e', 'da2fd609-d754-4feb-8acd-c4f9ff13ba96');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ChatroomId', N'UserId') AND [object_id] = OBJECT_ID(N'[UserChatrooms]'))
        SET IDENTITY_INSERT [UserChatrooms] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    CREATE INDEX [IX_Messages_ChatroomId] ON [Messages] ([ChatroomId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    CREATE INDEX [IX_Messages_UserId] ON [Messages] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    CREATE INDEX [IX_Rewards_UserId] ON [Rewards] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    CREATE INDEX [IX_UserChatrooms_UserId] ON [UserChatrooms] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200308165428_v1.0')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200308165428_v1.0', N'3.0.0');
END;

GO

