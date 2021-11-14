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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211105161857_StudentTable')
BEGIN
    CREATE TABLE [Students] (
        [Id] int NOT NULL IDENTITY,
        [StudName] nvarchar(max) NULL,
        [StudEmail] nvarchar(max) NULL,
        [StudRollNumber] nvarchar(max) NULL,
        [StudPassword] nvarchar(max) NULL,
        [StudPhoneNumber] nvarchar(max) NULL,
        [StudFatherName] nvarchar(max) NULL,
        [StudAddress] nvarchar(max) NULL,
        [StudYearAndBranch] nvarchar(max) NULL,
        [StudDOB] nvarchar(max) NULL,
        [StudGender] nvarchar(max) NULL,
        CONSTRAINT [PK_Students] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211105161857_StudentTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211105161857_StudentTable', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211105185537_TeacherTable')
BEGIN
    CREATE TABLE [Teachers] (
        [Id] int NOT NULL IDENTITY,
        [TeacherName] nvarchar(max) NULL,
        [TeacherEmail] nvarchar(max) NULL,
        [TeacherID] nvarchar(max) NULL,
        [TeacherPassword] nvarchar(max) NULL,
        [TeacherPhoneNumber] nvarchar(max) NULL,
        [TeacherAddress] nvarchar(max) NULL,
        [TeacherDegree] nvarchar(max) NULL,
        [TeacherDOB] nvarchar(max) NULL,
        [TeacherGender] nvarchar(max) NULL,
        CONSTRAINT [PK_Teachers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211105185537_TeacherTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211105185537_TeacherTable', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211106145230_AnonymousTable')
BEGIN
    CREATE TABLE [Anonymouss] (
        [Id] int NOT NULL IDENTITY,
        [Type] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Anonymouss] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211106145230_AnonymousTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211106145230_AnonymousTable', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211106161032_OrderTable')
BEGIN
    CREATE TABLE [Orders] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Items] nvarchar(max) NULL,
        [Total] nvarchar(max) NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211106161032_OrderTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211106161032_OrderTable', N'5.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211112152450_orderTableUpdated')
BEGIN
    ALTER TABLE [Orders] ADD [PhoneNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211112152450_orderTableUpdated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211112152450_orderTableUpdated', N'5.0.11');
END;
GO

COMMIT;
GO

