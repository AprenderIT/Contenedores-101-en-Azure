IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914072738_InitialMigration')
BEGIN
    CREATE TABLE [Websites] (
        [Id] uniqueidentifier NOT NULL,
        [ImageLink] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Link] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Websites] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914072738_InitialMigration')
BEGIN
    CREATE TABLE [Profiles] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Lastname] nvarchar(max) NOT NULL,
        [CreationTime] datetime2 NOT NULL,
        [WebsiteId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Profiles] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Profiles_Websites_WebsiteId] FOREIGN KEY ([WebsiteId]) REFERENCES [Websites] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914072738_InitialMigration')
BEGIN
    CREATE INDEX [IX_Profiles_WebsiteId] ON [Profiles] ([WebsiteId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914072738_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210914072738_InitialMigration', N'5.0.9');
END;
GO

COMMIT;
GO

