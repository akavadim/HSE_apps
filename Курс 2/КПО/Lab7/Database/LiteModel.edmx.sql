
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/08/2020 01:59:12
-- Generated from EDMX file: C:\Users\vadim\OneDrive\Рабочий стол\HSE\КПО\Lab7\Database\LiteModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ArnetAdmin];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BanUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bans] DROP CONSTRAINT [FK_BanUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPhone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Phones] DROP CONSTRAINT [FK_UserPhone];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEmail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emails] DROP CONSTRAINT [FK_UserEmail];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPassword]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Passwords] DROP CONSTRAINT [FK_UserPassword];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAgency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Agencies] DROP CONSTRAINT [FK_UserAgency];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAgent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Agents] DROP CONSTRAINT [FK_UserAgent];
GO
IF OBJECT_ID(N'[dbo].[FK_AgencyAgent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Agents] DROP CONSTRAINT [FK_AgencyAgent];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Bans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bans];
GO
IF OBJECT_ID(N'[dbo].[Phones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Phones];
GO
IF OBJECT_ID(N'[dbo].[Emails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emails];
GO
IF OBJECT_ID(N'[dbo].[Passwords]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Passwords];
GO
IF OBJECT_ID(N'[dbo].[Agencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Agencies];
GO
IF OBJECT_ID(N'[dbo].[Agents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Agents];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(25)  NOT NULL,
    [SecondName] nvarchar(25)  NULL,
    [MiddleName] nvarchar(25)  NULL,
    [Type] tinyint  NOT NULL,
    [DateFrom] datetime  NOT NULL,
    [DateTo] datetime  NULL
);
GO

-- Creating table 'Bans'
CREATE TABLE [dbo].[Bans] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Comment] nvarchar(200)  NOT NULL,
    [DateFrom] datetime  NOT NULL,
    [DateTo] datetime  NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Phones'
CREATE TABLE [dbo].[Phones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Number] nvarchar(20)  NOT NULL,
    [DateFrom] datetime  NOT NULL,
    [DateTo] datetime  NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Emails'
CREATE TABLE [dbo].[Emails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Value] nvarchar(30)  NOT NULL,
    [DateFrom] datetime  NOT NULL,
    [DateTo] datetime  NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Passwords'
CREATE TABLE [dbo].[Passwords] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Value] nvarchar(50)  NOT NULL,
    [DateFrom] datetime  NOT NULL,
    [DateTo] datetime  NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Agencies'
CREATE TABLE [dbo].[Agencies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OwnerId] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [DateFrom] datetime  NOT NULL,
    [DateTo] datetime  NULL,
    [Owner_Id] int  NOT NULL
);
GO

-- Creating table 'Agents'
CREATE TABLE [dbo].[Agents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(max)  NOT NULL,
    [AgencyId] nvarchar(max)  NOT NULL,
    [DateFrom] datetime  NOT NULL,
    [DateTo] datetime  NULL,
    [User_Id] int  NOT NULL,
    [Agency_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bans'
ALTER TABLE [dbo].[Bans]
ADD CONSTRAINT [PK_Bans]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Phones'
ALTER TABLE [dbo].[Phones]
ADD CONSTRAINT [PK_Phones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [PK_Emails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Passwords'
ALTER TABLE [dbo].[Passwords]
ADD CONSTRAINT [PK_Passwords]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Agencies'
ALTER TABLE [dbo].[Agencies]
ADD CONSTRAINT [PK_Agencies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Agents'
ALTER TABLE [dbo].[Agents]
ADD CONSTRAINT [PK_Agents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'Bans'
ALTER TABLE [dbo].[Bans]
ADD CONSTRAINT [FK_BanUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BanUser'
CREATE INDEX [IX_FK_BanUser]
ON [dbo].[Bans]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Phones'
ALTER TABLE [dbo].[Phones]
ADD CONSTRAINT [FK_UserPhone]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPhone'
CREATE INDEX [IX_FK_UserPhone]
ON [dbo].[Phones]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [FK_UserEmail]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEmail'
CREATE INDEX [IX_FK_UserEmail]
ON [dbo].[Emails]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Passwords'
ALTER TABLE [dbo].[Passwords]
ADD CONSTRAINT [FK_UserPassword]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPassword'
CREATE INDEX [IX_FK_UserPassword]
ON [dbo].[Passwords]
    ([User_Id]);
GO

-- Creating foreign key on [Owner_Id] in table 'Agencies'
ALTER TABLE [dbo].[Agencies]
ADD CONSTRAINT [FK_UserAgency]
    FOREIGN KEY ([Owner_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAgency'
CREATE INDEX [IX_FK_UserAgency]
ON [dbo].[Agencies]
    ([Owner_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Agents'
ALTER TABLE [dbo].[Agents]
ADD CONSTRAINT [FK_UserAgent]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAgent'
CREATE INDEX [IX_FK_UserAgent]
ON [dbo].[Agents]
    ([User_Id]);
GO

-- Creating foreign key on [Agency_Id] in table 'Agents'
ALTER TABLE [dbo].[Agents]
ADD CONSTRAINT [FK_AgencyAgent]
    FOREIGN KEY ([Agency_Id])
    REFERENCES [dbo].[Agencies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AgencyAgent'
CREATE INDEX [IX_FK_AgencyAgent]
ON [dbo].[Agents]
    ([Agency_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------