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

CREATE TABLE [Departamentos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Sigla] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Departamentos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Funcionarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Foto] nvarchar(max) NOT NULL,
    [RG] nvarchar(max) NOT NULL,
    [DepartamentoId] int NOT NULL,
    CONSTRAINT [PK_Funcionarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Funcionarios_Departamentos_DepartamentoId] FOREIGN KEY ([DepartamentoId]) REFERENCES [Departamentos] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Funcionarios_DepartamentoId] ON [Funcionarios] ([DepartamentoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240113000731_initial', N'8.0.1');
GO

COMMIT;
GO

