
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/16/2017 13:18:47
-- Generated from EDMX file: C:\Users\Joseph\documents\visual studio 2017\Projects\GameBracketManager\GameBracketManager\Infrastructure\GameBracketModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CS487];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Bracket_Bracket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bracket] DROP CONSTRAINT [FK_Bracket_Bracket];
GO
IF OBJECT_ID(N'[GameBracketManagerInfrastructureStoreContainer].[FK_BracketParticipants_Bracket]', 'F') IS NOT NULL
    ALTER TABLE [GameBracketManagerInfrastructureStoreContainer].[BracketParticipants] DROP CONSTRAINT [FK_BracketParticipants_Bracket];
GO
IF OBJECT_ID(N'[GameBracketManagerInfrastructureStoreContainer].[FK_BracketParticipants_Team]', 'F') IS NOT NULL
    ALTER TABLE [GameBracketManagerInfrastructureStoreContainer].[BracketParticipants] DROP CONSTRAINT [FK_BracketParticipants_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_Player_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Player] DROP CONSTRAINT [FK_Player_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_Team_Game]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Team] DROP CONSTRAINT [FK_Team_Game];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bracket]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bracket];
GO
IF OBJECT_ID(N'[dbo].[Game]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Game];
GO
IF OBJECT_ID(N'[dbo].[Player]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Player];
GO
IF OBJECT_ID(N'[dbo].[Team]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Team];
GO
IF OBJECT_ID(N'[GameBracketManagerInfrastructureStoreContainer].[BracketParticipants]', 'U') IS NOT NULL
    DROP TABLE [GameBracketManagerInfrastructureStoreContainer].[BracketParticipants];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Brackets'
CREATE TABLE [dbo].[Brackets] (
    [Name] nvarchar(50)  NOT NULL,
    [PointsPerWin] int  NOT NULL,
    [EventDateTime] datetime  NOT NULL,
    [GameName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Games'
CREATE TABLE [dbo].[Games] (
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Players'
CREATE TABLE [dbo].[Players] (
    [Id] uniqueidentifier  NOT NULL,
    [DisplayName] nvarchar(50)  NOT NULL,
    [FirstName] nvarchar(25)  NOT NULL,
    [LastName] nvarchar(25)  NOT NULL,
    [TeamId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Wins] int  NOT NULL,
    [Losses] int  NOT NULL,
    [Score] int  NOT NULL,
    [GameName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'BracketParticipants'
CREATE TABLE [dbo].[BracketParticipants] (
    [Brackets_Name] nvarchar(50)  NOT NULL,
    [Teams_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Name] in table 'Brackets'
ALTER TABLE [dbo].[Brackets]
ADD CONSTRAINT [PK_Brackets]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [Name] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [PK_Games]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [Id] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [PK_Players]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Brackets_Name], [Teams_Id] in table 'BracketParticipants'
ALTER TABLE [dbo].[BracketParticipants]
ADD CONSTRAINT [PK_BracketParticipants]
    PRIMARY KEY CLUSTERED ([Brackets_Name], [Teams_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GameName] in table 'Brackets'
ALTER TABLE [dbo].[Brackets]
ADD CONSTRAINT [FK_Bracket_Bracket]
    FOREIGN KEY ([GameName])
    REFERENCES [dbo].[Games]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Bracket_Bracket'
CREATE INDEX [IX_FK_Bracket_Bracket]
ON [dbo].[Brackets]
    ([GameName]);
GO

-- Creating foreign key on [GameName] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [FK_Team_Game]
    FOREIGN KEY ([GameName])
    REFERENCES [dbo].[Games]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Team_Game'
CREATE INDEX [IX_FK_Team_Game]
ON [dbo].[Teams]
    ([GameName]);
GO

-- Creating foreign key on [TeamId] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [FK_Player_Team]
    FOREIGN KEY ([TeamId])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Player_Team'
CREATE INDEX [IX_FK_Player_Team]
ON [dbo].[Players]
    ([TeamId]);
GO

-- Creating foreign key on [Brackets_Name] in table 'BracketParticipants'
ALTER TABLE [dbo].[BracketParticipants]
ADD CONSTRAINT [FK_BracketParticipants_Bracket]
    FOREIGN KEY ([Brackets_Name])
    REFERENCES [dbo].[Brackets]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Teams_Id] in table 'BracketParticipants'
ALTER TABLE [dbo].[BracketParticipants]
ADD CONSTRAINT [FK_BracketParticipants_Team]
    FOREIGN KEY ([Teams_Id])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BracketParticipants_Team'
CREATE INDEX [IX_FK_BracketParticipants_Team]
ON [dbo].[BracketParticipants]
    ([Teams_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------