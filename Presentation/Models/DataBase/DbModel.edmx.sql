
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/23/2016 09:19:00
-- Generated from EDMX file: D:\Vs2013Projects\Gitarist\Presentation\Models\DataBase\DbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [gitarist];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SongForeign_ArtistForeign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongForeign] DROP CONSTRAINT [FK_SongForeign_ArtistForeign];
GO
IF OBJECT_ID(N'[dbo].[FK_SongForeign_Theme]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongForeign] DROP CONSTRAINT [FK_SongForeign_Theme];
GO
IF OBJECT_ID(N'[dbo].[FK_SongRusian_ArtistRusian]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongRusian] DROP CONSTRAINT [FK_SongRusian_ArtistRusian];
GO
IF OBJECT_ID(N'[dbo].[FK_SongRusian_Theme]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongRusian] DROP CONSTRAINT [FK_SongRusian_Theme];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ArtistForeign]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArtistForeign];
GO
IF OBJECT_ID(N'[dbo].[ArtistRusian]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArtistRusian];
GO
IF OBJECT_ID(N'[dbo].[Chords]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Chords];
GO
IF OBJECT_ID(N'[dbo].[SongForeign]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SongForeign];
GO
IF OBJECT_ID(N'[dbo].[SongRusian]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SongRusian];
GO
IF OBJECT_ID(N'[dbo].[Theme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Theme];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ArtistForeigns'
CREATE TABLE [dbo].[ArtistForeigns] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [biography] nvarchar(max)  NULL,
    [deleted] bit  NOT NULL,
    [isPopular] bit  NOT NULL,
    [clearUrlName] nvarchar(100)  NULL
);
GO

-- Creating table 'ArtistRusians'
CREATE TABLE [dbo].[ArtistRusians] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [biography] nvarchar(max)  NULL,
    [deleted] bit  NOT NULL,
    [isPopular] bit  NOT NULL,
    [clearUrlName] nvarchar(100)  NULL
);
GO

-- Creating table 'Chords'
CREATE TABLE [dbo].[Chords] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(15)  NOT NULL,
    [description] varbinary(50)  NOT NULL,
    [imageUrl] varchar(200)  NULL
);
GO

-- Creating table 'SongForeigns'
CREATE TABLE [dbo].[SongForeigns] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [artistId] int  NULL,
    [themeId] int  NULL,
    [isNew] bit  NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [chords] nvarchar(max)  NOT NULL,
    [deleted] bit  NOT NULL,
    [isPopular] bit  NOT NULL,
    [datecreate] datetime  NOT NULL,
    [clearUrlName] nvarchar(100)  NULL
);
GO

-- Creating table 'SongRusians'
CREATE TABLE [dbo].[SongRusians] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [artistId] int  NULL,
    [themeId] int  NULL,
    [isNew] bit  NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [chords] nvarchar(max)  NOT NULL,
    [deleted] bit  NOT NULL,
    [isPopular] bit  NOT NULL,
    [datecreate] datetime  NOT NULL,
    [clearUrlName] nvarchar(100)  NULL
);
GO

-- Creating table 'Themes'
CREATE TABLE [dbo].[Themes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [deleted] bit  NOT NULL,
    [clearUrlName] nvarchar(100)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'ArtistForeigns'
ALTER TABLE [dbo].[ArtistForeigns]
ADD CONSTRAINT [PK_ArtistForeigns]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ArtistRusians'
ALTER TABLE [dbo].[ArtistRusians]
ADD CONSTRAINT [PK_ArtistRusians]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Chords'
ALTER TABLE [dbo].[Chords]
ADD CONSTRAINT [PK_Chords]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SongForeigns'
ALTER TABLE [dbo].[SongForeigns]
ADD CONSTRAINT [PK_SongForeigns]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SongRusians'
ALTER TABLE [dbo].[SongRusians]
ADD CONSTRAINT [PK_SongRusians]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Themes'
ALTER TABLE [dbo].[Themes]
ADD CONSTRAINT [PK_Themes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [artistId] in table 'SongForeigns'
ALTER TABLE [dbo].[SongForeigns]
ADD CONSTRAINT [FK_SongForeign_ArtistForeign]
    FOREIGN KEY ([artistId])
    REFERENCES [dbo].[ArtistForeigns]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongForeign_ArtistForeign'
CREATE INDEX [IX_FK_SongForeign_ArtistForeign]
ON [dbo].[SongForeigns]
    ([artistId]);
GO

-- Creating foreign key on [artistId] in table 'SongRusians'
ALTER TABLE [dbo].[SongRusians]
ADD CONSTRAINT [FK_SongRusian_ArtistRusian]
    FOREIGN KEY ([artistId])
    REFERENCES [dbo].[ArtistRusians]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongRusian_ArtistRusian'
CREATE INDEX [IX_FK_SongRusian_ArtistRusian]
ON [dbo].[SongRusians]
    ([artistId]);
GO

-- Creating foreign key on [themeId] in table 'SongForeigns'
ALTER TABLE [dbo].[SongForeigns]
ADD CONSTRAINT [FK_SongForeign_Theme]
    FOREIGN KEY ([themeId])
    REFERENCES [dbo].[Themes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongForeign_Theme'
CREATE INDEX [IX_FK_SongForeign_Theme]
ON [dbo].[SongForeigns]
    ([themeId]);
GO

-- Creating foreign key on [themeId] in table 'SongRusians'
ALTER TABLE [dbo].[SongRusians]
ADD CONSTRAINT [FK_SongRusian_Theme]
    FOREIGN KEY ([themeId])
    REFERENCES [dbo].[Themes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongRusian_Theme'
CREATE INDEX [IX_FK_SongRusian_Theme]
ON [dbo].[SongRusians]
    ([themeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------