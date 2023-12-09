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

CREATE TABLE [Fornecedores] (
    [idfornecedor] int NOT NULL IDENTITY,
    [nome] nvarchar(60) NOT NULL,
    [email] nvarchar(100) NOT NULL,
    [phone] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Fornecedores] PRIMARY KEY ([idfornecedor])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Fornecedor IDFornecedor as a primary key';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Fornecedores', 'COLUMN', N'idfornecedor';
SET @description = N'Fornecedor nome';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Fornecedores', 'COLUMN', N'nome';
SET @description = N'Fornecedor email';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Fornecedores', 'COLUMN', N'email';
SET @description = N'Fornecedor phone number';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Fornecedores', 'COLUMN', N'phone';
GO

CREATE TABLE [PratoRestaurantes] (
    [idprato] int NOT NULL IDENTITY,
    [IdRes] int NOT NULL,
    [nomeprato] nvarchar(60) NOT NULL,
    [descricaoprato] nvarchar(max) NOT NULL,
    [PrecoPrato] int NOT NULL,
    CONSTRAINT [PK_PratoRestaurantes] PRIMARY KEY ([idprato])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Prato IDPrato as a primary key';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PratoRestaurantes', 'COLUMN', N'idprato';
SET @description = N'Prato nome';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PratoRestaurantes', 'COLUMN', N'nomeprato';
SET @description = N'Descricao do prato';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PratoRestaurantes', 'COLUMN', N'descricaoprato';
SET @description = N'Preco do prato';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PratoRestaurantes', 'COLUMN', N'PrecoPrato';
GO

CREATE TABLE [Restaurantes] (
    [idres] int NOT NULL IDENTITY,
    [IdFornecedor] int NOT NULL,
    [nomeres] nvarchar(60) NOT NULL,
    CONSTRAINT [PK_Restaurantes] PRIMARY KEY ([idres])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Restaurante IDRestaurante as a primary key';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Restaurantes', 'COLUMN', N'idres';
SET @description = N'Restaurante nome';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Restaurantes', 'COLUMN', N'nomeres';
GO

CREATE TABLE [Produtos] (
    [idprod] int NOT NULL IDENTITY,
    [IdFornecedor] int NOT NULL,
    [nomeprod] nvarchar(60) NOT NULL,
    [descricaoprod] nvarchar(max) NOT NULL,
    [PrecoProd] int NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([idprod]),
    CONSTRAINT [FK_Produtos_Fornecedores_IdFornecedor] FOREIGN KEY ([IdFornecedor]) REFERENCES [Fornecedores] ([idfornecedor]) ON DELETE CASCADE
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Produto IDProd as a primary key';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Produtos', 'COLUMN', N'idprod';
SET @description = N'Produto nome';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Produtos', 'COLUMN', N'nomeprod';
SET @description = N'Descricao do produto';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Produtos', 'COLUMN', N'descricaoprod';
SET @description = N'Preco do produto';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Produtos', 'COLUMN', N'PrecoProd';
GO

CREATE TABLE [RestauranteFornecedor] (
    [FornecedoresIdFornecedor] int NOT NULL,
    [RestaurantesIdRes] int NOT NULL,
    CONSTRAINT [PK_RestauranteFornecedor] PRIMARY KEY ([FornecedoresIdFornecedor], [RestaurantesIdRes]),
    CONSTRAINT [FK_RestauranteFornecedor_Fornecedores_FornecedoresIdFornecedor] FOREIGN KEY ([FornecedoresIdFornecedor]) REFERENCES [Fornecedores] ([idfornecedor]) ON DELETE CASCADE,
    CONSTRAINT [FK_RestauranteFornecedor_Restaurantes_RestaurantesIdRes] FOREIGN KEY ([RestaurantesIdRes]) REFERENCES [Restaurantes] ([idres]) ON DELETE CASCADE
);
GO

CREATE TABLE [RestaurantePratoAssociacao] (
    [PratosRestaurantesIdPrato] int NOT NULL,
    [RestaurantesIdRes] int NOT NULL,
    CONSTRAINT [PK_RestaurantePratoAssociacao] PRIMARY KEY ([PratosRestaurantesIdPrato], [RestaurantesIdRes]),
    CONSTRAINT [FK_RestaurantePratoAssociacao_PratoRestaurantes_PratosRestaurantesIdPrato] FOREIGN KEY ([PratosRestaurantesIdPrato]) REFERENCES [PratoRestaurantes] ([idprato]) ON DELETE CASCADE,
    CONSTRAINT [FK_RestaurantePratoAssociacao_Restaurantes_RestaurantesIdRes] FOREIGN KEY ([RestaurantesIdRes]) REFERENCES [Restaurantes] ([idres]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idfornecedor', N'email', N'nome', N'phone') AND [object_id] = OBJECT_ID(N'[Fornecedores]'))
    SET IDENTITY_INSERT [Fornecedores] ON;
INSERT INTO [Fornecedores] ([idfornecedor], [email], [nome], [phone])
VALUES (1, N'jaojoao@gmail.com', N'Jão João', N'40028922');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idfornecedor', N'email', N'nome', N'phone') AND [object_id] = OBJECT_ID(N'[Fornecedores]'))
    SET IDENTITY_INSERT [Fornecedores] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idprato', N'descricaoprato', N'IdRes', N'nomeprato', N'PrecoPrato') AND [object_id] = OBJECT_ID(N'[PratoRestaurantes]'))
    SET IDENTITY_INSERT [PratoRestaurantes] ON;
INSERT INTO [PratoRestaurantes] ([idprato], [descricaoprato], [IdRes], [nomeprato], [PrecoPrato])
VALUES (1, N'Lasanha vegana de aabobrinha, cogumelos e espinafre', 1, N'Lasanha de abobrinha vegana', 32);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idprato', N'descricaoprato', N'IdRes', N'nomeprato', N'PrecoPrato') AND [object_id] = OBJECT_ID(N'[PratoRestaurantes]'))
    SET IDENTITY_INSERT [PratoRestaurantes] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idres', N'IdFornecedor', N'nomeres') AND [object_id] = OBJECT_ID(N'[Restaurantes]'))
    SET IDENTITY_INSERT [Restaurantes] ON;
INSERT INTO [Restaurantes] ([idres], [IdFornecedor], [nomeres])
VALUES (1, 1, N'Brown kitchen');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idres', N'IdFornecedor', N'nomeres') AND [object_id] = OBJECT_ID(N'[Restaurantes]'))
    SET IDENTITY_INSERT [Restaurantes] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idprod', N'descricaoprod', N'IdFornecedor', N'nomeprod', N'PrecoProd') AND [object_id] = OBJECT_ID(N'[Produtos]'))
    SET IDENTITY_INSERT [Produtos] ON;
INSERT INTO [Produtos] ([idprod], [descricaoprod], [IdFornecedor], [nomeprod], [PrecoProd])
VALUES (1, N'Shampoo com ingredientes naturais. Cruelty-free e vegano', 1, N'Shampoo de menta vegano', 25);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idprod', N'descricaoprod', N'IdFornecedor', N'nomeprod', N'PrecoProd') AND [object_id] = OBJECT_ID(N'[Produtos]'))
    SET IDENTITY_INSERT [Produtos] OFF;
GO

CREATE INDEX [IX_Produtos_IdFornecedor] ON [Produtos] ([IdFornecedor]);
GO

CREATE INDEX [IX_RestauranteFornecedor_RestaurantesIdRes] ON [RestauranteFornecedor] ([RestaurantesIdRes]);
GO

CREATE INDEX [IX_RestaurantePratoAssociacao_RestaurantesIdRes] ON [RestaurantePratoAssociacao] ([RestaurantesIdRes]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231207193613_first', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231209222557_second', N'7.0.10');
GO

COMMIT;
GO

